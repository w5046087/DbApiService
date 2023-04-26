using DpApiServer.WeiXinLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DpApiServer.Controllers.wxApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallBackController : ControllerBase
    {
        private readonly WxDetail _wxDetail;
        public CallBackController(WxDetail wxDetail)
        {
            _wxDetail = wxDetail;
        }

        [HttpGet]
        public ActionResult Test(string signature,string timestamp,string nonce,string echostr) {
        
            if (_wxDetail.CheckSource(signature, timestamp, nonce)) {
                return Content(echostr);
            }

            return Content("验证失败");
        }
    }
}
