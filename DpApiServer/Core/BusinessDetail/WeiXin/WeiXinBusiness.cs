
using DeeplHelperDb.Service;
using DpApiServer.Core.UseLib.WeiXinLib.OpenPlatform;
using DpApiServer.Core.UseLib.WeiXinLib.wxModel;
using Microsoft.AspNetCore.Mvc;

namespace DpApiServer.Core.BusinessDetail.WeiXin
{
    public class WeiXinBusiness
    {
        private readonly WxOpenPlatform wxOpenPlatform1;
        private readonly A_AccountService accountService;
        public WeiXinBusiness(WxOpenPlatform wxOpenPlatform,A_AccountService a_AccountService   ) { 
            wxOpenPlatform1 = wxOpenPlatform;
            accountService = a_AccountService;
        }
        public async Task<WxUserInfoM?> WxAuthorLogin(string code, string role) {
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(role)) return null;

            var accountAuthorModel =await wxOpenPlatform1.GetWxAccountOpenID(code, role);
            if (accountAuthorModel == null) {

                return null;
            }

            var getAccountInfo = await wxOpenPlatform1.GetWxAccountInfo(accountAuthorModel.openid);

            if (getAccountInfo == null) {
                return null;
            }
            return getAccountInfo;



        }
        public bool Verify(string s,string t ,string n) {

            return wxOpenPlatform1.CheckSource(s, t, n);
        }




    }
}
