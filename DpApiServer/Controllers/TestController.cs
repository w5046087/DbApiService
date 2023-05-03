//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Data.Common;
//using DeeplHelperDb.Service;
//using DeeplHelperDb.Model;
//using System;

//namespace DpApiServer.Controllers
//{
//    [Route("testapi/[controller]")]
//    [ApiController]
//    public class TestController : ControllerBase
//    {
//        private readonly ILogger<TestController> _logger;
    
//        private readonly AccountService _accountService;
       

//        public TestController(ILogger<TestController> logger, AccountService _accountService)
//        {
//            _logger = logger;
//            this._accountService = _accountService;
//        }
//        private WeiXinOpen.WxOpenDetail WxOpenDetail = new WeiXinOpen.WxOpenDetail();
//        [HttpGet("/logintest")]
//        public async Task<ActionResult> Login(string code){
//            var wxOpenLogin = await WxOpenDetail.WxOpenLogin(code);
//            if (wxOpenLogin == null)
//            {
//                return Content("微信授权错误");
//            }
//            else
//            {
//                if (string.IsNullOrWhiteSpace(wxOpenLogin.openid)){
//                    return Content("返回的openid为空");
//                }
//                //获取用户是否存在
//                var currentUser = _accountService.GetByWxOpenID(wxOpenLogin.openid);
//                if (currentUser == null)
//                {
//                    var _cUid = Guid.NewGuid();
//                    var a_Account = new A_Account()
//                    {
//                        cUid = _cUid,
//                        cWx_Openid = wxOpenLogin.openid,
//                        cWx_Nick = wxOpenLogin.nickname,
//                        cWx_Unionid = wxOpenLogin.unionid,
//                        cWx_Img = wxOpenLogin.headimgurl,
//                        cWx_Sex = wxOpenLogin.sex,



//                    };

//                    int newUserId = await _accountService.Insert(a_Account);
//                    if (newUserId!=1)
//                    {
//                        //这里是数据库插入新用户失败,一般都会成功,除非出现guid相同或者openid相同,基本不会
//                        return Content("插入用户失败");
//                    }
//                    else
//                    {

//                        return Content(_cUid.ToString());
//                        //这里就是有ID了,根据ID返回JWT授权就ok了.
//                    }
//                }
//                else
//                {
//                    return Content($"已存在的用户");
//                }
//            }
//        }

//        //[HttpGet]
//        //public IActionResult GetAccessToken()
//        //{
            

//        //    WxDetail wxDetail = new WxDetail(); //23188.23  22361 185 641 8月12

//        //    return Content(wxDetail.SendWxNotice_SysEarning("oceUrv2z45wZuAzPX-Z7gYF7tWWA", "2", "3", "4", "5"));        }
//        //[HttpGet(Name = "/sendNotice")]
//        //public IActionResult SendNotice()
//        //{

//        //    WxDetail wxDetail = new WxDetail();
//        //    return Content(wxDetail.SendWxNotice_SysEarning("1", "2", "3", "4", "5"));
//        //}
     

//    }
//}
