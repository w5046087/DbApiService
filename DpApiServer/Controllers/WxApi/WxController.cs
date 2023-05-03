
using DeeplHelperDb.Service;
using DpApiServer.Core.BusinessDetail.WeiXin;
using DpApiServer.JwtLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DpApiServer.Controllers.wxApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class WxController : ControllerBase
    {
        private readonly WeiXinBusiness weiXinBusiness;
        private readonly A_AccountService a_AccountService;
        private readonly JwtLib.JwtAuthManager jwtAuthManager;
        public WxController(WeiXinBusiness weiXinBusiness, A_AccountService a_AccountService, JwtAuthManager jwtAuthManager)
        {
            this.weiXinBusiness = weiXinBusiness;
            this.a_AccountService = a_AccountService;
            this.jwtAuthManager = jwtAuthManager;
        }


        [HttpGet(Name ="/wxAuthVerify")]
        public ActionResult Verify(string signature, string timestamp, string nonce, string echostr)
        {
            if (weiXinBusiness.Verify(signature, timestamp, nonce))
            {
                return Content(echostr);
            }
            return Content("验证失败");
        }

        [HttpGet(Name = "/wxAuthorLogin")]
        public async Task<IActionResult> WxOpenAuthorLogin(string code,string role) {
            if(string.IsNullOrEmpty(code)||string.IsNullOrEmpty(role)) return Unauthorized();

            var wxAccountModel =await weiXinBusiness.WxAuthorLogin(code, role);
            if(wxAccountModel == null) return Unauthorized();

            //然后根据获取到的微信用户信息,来判断数据库是否存在这个用户,不存在就创建,存在就返回JWT登陆的Token即可


            var isExistAccount = a_AccountService.IsExistAccount(wxAccountModel.openid);

            if (isExistAccount != null)
            {
                return Ok(jwtAuthManager.CreateLoginTokenJson(isExistAccount.ToString(), "chrome"));
                //这里是存在用户,直接返回吗?因为当前用户过了微信的验证才能走到这一步的,直接返回也行.
                //1.jwt直接生成token返回信息即可
            }
            else
            {
                Guid g = Guid.NewGuid();
                var newAccount = a_AccountService.Insert(new DeeplHelperDb.Model.A_AccountModel
                {
                    cWx_Openid = wxAccountModel.openid,
                    cWx_Img = wxAccountModel.headimgurl,
                    cWx_Sex = Convert.ToBoolean(wxAccountModel.sex), //这里注意可能会出现问题
                    cWx_Nick = wxAccountModel.nickname,
                    cUid = g
                });
                if (newAccount == 1)
                {
                    return Ok( jwtAuthManager.CreateLoginTokenJson(g.ToString(), "chrome"));
                }
                return Ok("插入用户失败.");
            }

        }
    }
}
