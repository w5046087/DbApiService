using DeeplHelperDb.Service;
using DpApiServer.JwtLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace DpApiServer.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AccountController : ControllerBase
    {
        //private readonly Core.Account.AccountBusiness _accountBusiness;
        private readonly A_AccountService _accountService;
        public AccountController(A_AccountService a_AccountService)
        {
            //_accountBusiness = accountBusiness;
            _accountService = a_AccountService;
        }
        [h]

        //[AllowAnonymous]
        //[HttpGet("/getAccountInfo")]
        //public IActionResult GetAccountInfo()
        //{


        //}

        //[AllowAnonymous]
        //[HttpGet("/getAccountMsg")]

        //public IActionResult GetAccountMsg()
        //{

    }
}