using Microsoft.AspNetCore.Mvc;

namespace DpApiServer.WeiXinOpen
{
    public class WxOpenDetail
    {
        //https://open.weixin.qq.com/connect/qrconnect?appid=wx10cc41b9fcf3227d&redirect_uri=http://api.deeplhelper.com/logintest&response_type=code&scope=snsapi_login&state=STATE#wechat_redirect
        //上面是前端调用的
        private readonly string wxOpenAppId= "wx10cc41b9fcf3227d";
        private readonly string wxSecret = "6c04aa66e831d4747666e5fd944825bb";
        string Url_GetUserInfo = "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}";
        private string Url_GetAccessToken
        {
            //https://api.weixin.qq.com/sns/oauth2/access_token?appid=wx10cc41b9fcf3227d&secret=6c04aa66e831d4747666e5fd944825bb&code=081Rz9100uzMxO1lZ1400GDC5I2Rz91s&grant_type=authorization_code
            get { return $"https://api.weixin.qq.com/sns/oauth2/access_token?appid={wxOpenAppId}&secret={wxSecret}&code={0}&grant_type=authorization_code"; }
        }
        public async Task<Model.WxUserInfoM?> WxOpenLogin(string code) {

            var response = await GetLoginAccessToken(code);
            if (response == null)
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(response.access_token))
            {
                return null;
            }
            var response2 = await GetWxOpenUserInfo(response.access_token, response.openid);
            //新用户插入数据库  然后返回新用户的JwtToken信息,正确可以访问所有数据,不正确就未授权
            return response2;

        }

        private async Task<Model.WxUserInfoM?>GetWxOpenUserInfo(string accessToken,string openid) {
            using (var client = new HttpClient())
            {
                var response=await Get(string.Format(Url_GetUserInfo, accessToken, openid));
                var result = await response.Content.ReadFromJsonAsync<Model.WxUserInfoM>();
                return result;
            }
        }
        private  async Task<Model.LoginAccessTokenM?> GetLoginAccessToken(string code) {

            using (var client = new HttpClient())
            {
                string reqUrl = $"https://api.weixin.qq.com/sns/oauth2/access_token?appid={wxOpenAppId}&secret={wxSecret}&code={code}&grant_type=authorization_code";
                var response =await Get(reqUrl);
                if (response == null) { return null; }
                var result = await response.Content.ReadFromJsonAsync<Model.LoginAccessTokenM>();
                return result;
            }
        }

        private async Task<HttpResponseMessage> Get(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                return response;
            }
        }
        private Task<HttpResponseMessage> Post(string url, HttpContent httpContent)
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, httpContent);
                return response;
            }
        }


    }
}
