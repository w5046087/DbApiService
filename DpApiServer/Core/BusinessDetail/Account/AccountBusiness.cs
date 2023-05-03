using DeeplHelperDb.Service;
using DpApiServer.JwtLib;
using DpApiServer.WeiXinOpen;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using DeeplHelperDb.Model;

namespace DpApiServer.Core.BusinessDetail.Account
{
    public class AccountBusiness
    {
        private readonly WxOpenDetail _wxOpenDetail;
        private readonly A_AccountService _accountService;

        public AccountBusiness( A_AccountService _accountService)
        {
            _wxOpenDetail = new WxOpenDetail();
            this._accountService = _accountService;
        }
        public string? GetAccountInfo(string cUid) {

            //var result = _accountService.GetAll(new { cUid = cUid }).FirstOrDefault();
            //if (result!=null) {
            //    return JsonConvert.SerializeObject(new
            //    {



            //    });
            //}
            //return null;
        } 
        
        
       
    }
}
