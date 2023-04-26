using DpApiServer.DbHelper;
using DpApiServer.JwtLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace DpApiServer.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Core.Account.AccountBusiness _accountBusiness;
        public AccountController(Core.Account.AccountBusiness accountBusiness) { 
            _accountBusiness = accountBusiness;
        }
        [HttpGet("/authlogin")]
        public async Task<IActionResult> Login(string code,string role) {
            // string? userName = _Context.User.Claims?.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Name)?.Value;
            var result = await _accountBusiness.WxOpenLogin(code, role);
            if (result.Code == 200&&result.Content!=null) {
                return Content(result.Content);
            }
            return new JsonResult(result);
        }
        [HttpGet("/getUserInfo")]
        [Authorize]
        public IActionResult GetUserInfo(HttpContext httpContext) {
            string? userId = httpContext.User.Claims?.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Name)?.Value;
            if (userId != null)
            {
                var result = _accountBusiness.GetUserInfo(userId);
                if (result.Code == 200) return Content(result.Content);
                return new JsonResult(result);
            }
            return Content("数据出错");
        }

        [HttpGet("/createTestToken")]
        public async Task<IActionResult> CreateTestToken()
        {
          return Content (await _accountBusiness.CreateTestToken());
        }
        [HttpPost("/refreshUserToken")]
        public async  Task<IActionResult> RefreshUserToken([FromForm] string refreshtoken) {
            if (string.IsNullOrWhiteSpace(refreshtoken)) return Content("Invalid Token");
            var newToken = await _accountBusiness.RefreshUserToken(refreshtoken);
            if (newToken.Code == 200) return Ok(newToken.Content);
            return new JsonResult(newToken);
        }
    }
}
