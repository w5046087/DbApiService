using DeeplHelperDb.Service;
using DeeplHelperDb.Model;

using DpApiServer.Global.RsMsg;
using DpApiServer.JwtLib;
using DpApiServer.WeiXinOpen;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Runtime;

namespace DpApiServer.Core.Account
{
    public class AccountBusiness
    {
        private readonly JwtAuthManager _jwtAuthManager;
        private readonly WxOpenDetail _wxOpenDetail;
        private readonly AccountService _account;
        //private readonly IAccount _account;
        public AccountBusiness(JwtAuthManager jwtAuthManager, AccountService account)
        {
            _jwtAuthManager = jwtAuthManager;
            _wxOpenDetail = new WxOpenDetail();
            _account= account;  
        }
        //成功返回accessToken以及refreshToken
        public async Task<RsMsgSimple> WxOpenLogin(string code,string role) {

            var wxOpenLogin = await _wxOpenDetail.WxOpenLogin(code);
            if (wxOpenLogin == null)
            {
                return new RsMsgSimple(-1, "微信登陆失败");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(wxOpenLogin.openid))
                {
                    return new RsMsgSimple(-1, "返回的openid为空") ;
                }
                //获取用户是否存在
                var currentUser = _account.GetByWxOpenID(wxOpenLogin.openid);
                if (currentUser == null)
                {

                    var _cUid = Guid.NewGuid();
                    var a_Account = new A_Account()
                    {
                        cUid= _cUid,
                        cWx_Openid = wxOpenLogin.openid,
                        cWx_Nick = wxOpenLogin.nickname,
                        cWx_Unionid=wxOpenLogin.unionid,
                        cWx_Img=wxOpenLogin.headimgurl,
                        cWx_Sex=wxOpenLogin.sex,

                 

                    };
                    int newUserId = await _account.Insert(a_Account);
                    if (newUserId != 0)
                    {
                        return new RsMsgSimple(-1, "新增用户失败,请重试");
                    }
                    else {
                        JwtAuthResult jwtInfo = await _jwtAuthManager.GenerateLoginToken(_cUid.ToString(), role);
                        if (string.IsNullOrWhiteSpace(jwtInfo.access_token)) return new RsMsgSimple(-1, "accessToken获取失败");
                        string jwtInfoJson = JsonConvert.SerializeObject(jwtInfo);
                        return new RsMsgSimple(200, jwtInfoJson);
                    }
                    //if (string.IsNullOrWhiteSpace(newUserId))
                    //{
                    //    //这里是数据库插入新用户失败,一般都会成功,除非出现guid相同或者openid相同,基本不会
                    //    return new RsMsgSimple(-1, "新增用户失败,请重试");
                    //}
                    //else
                    //{
                    //    JwtAuthResult jwtInfo=  await _jwtAuthManager.GenerateLoginToken(newUserId, role);
                    //    if (string.IsNullOrWhiteSpace(jwtInfo.access_token)) return new RsMsgSimple(-1,"accessToken获取失败");
                    //    string jwtInfoJson = JsonConvert.SerializeObject(jwtInfo);
                    //    return new RsMsgSimple(200, jwtInfoJson);
                    //    //这里就是有ID了,根据ID返回JWT授权就ok了.
                    //}
                }
                else
                {
                    return new RsMsgSimple(200,"用户已存在") ;
                }
            }

        }
        public RsMsgSimple GetUserInfo(string id) { 
            var result=_account.Get(id);
            if (result == null)
                return new RsMsgSimple(-1, "用户不存在");
            return new RsMsgSimple(200,JsonConvert.SerializeObject(result));
        }
        public async Task<string> CreateTestToken()
        {
            return JsonConvert.SerializeObject(await _jwtAuthManager.GenerateLoginToken("zzh", "web"));
        }
        public async Task<RsMsgSimple> RefreshUserToken(string refreshToken)
        {
            var result=await _jwtAuthManager.RefresnUserToken(refreshToken);
            return result;
        }
    }
}
