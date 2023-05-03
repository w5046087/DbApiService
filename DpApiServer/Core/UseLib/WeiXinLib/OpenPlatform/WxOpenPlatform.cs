using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using DpApiServer.Core.UseLib.Http;
using DpApiServer.Core.UseLib.WeiXinLib.wxModel;

namespace DpApiServer.Core.UseLib.WeiXinLib.OpenPlatform
{
    public class WxOpenPlatform
    {
        private readonly ISend _SendRequest;
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;
        private readonly string? _wxOpenID;
        private readonly string? _wxSkey;

        public WxOpenPlatform(SendRequest sendRequest, IMemoryCache memoryCache, IConfiguration configuration)
        {
            _SendRequest = sendRequest;
            _memoryCache = memoryCache;
            _configuration = configuration;

            _wxOpenID = _configuration.GetSection("[wxOpenPlatfromInfo:ID]").Value;
            _wxSkey = _configuration.GetSection("[wxOpenPlatfromInfo:Skey]").Value;
        }

        //private string wxId = "wxe32d968adde60610";
        //private string wxSKey = "66c8a43232d43a60acd4700c867662b2";

        #region 登陆类相关的方法
        private async Task<string?> GetAccessToken()
        {
            if (_memoryCache.TryGetValue("wxOpenAccessToken", out string? accessToken))
            {
                return accessToken;
            }
            else
            {
                if (_wxOpenID == null || _wxSkey == null)
                {

                    return null;
                }

                var response = await _SendRequest.GetAsync(string.Format(accessToken_Url, _wxOpenID, _wxSkey));

                var result = await response.Content.ReadFromJsonAsync<AccessTokenModel>();

                if (result == null || string.IsNullOrWhiteSpace(result.access_token))
                    return null;

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(7000))
                        .SetPriority(CacheItemPriority.Normal)
                        .SetSize(1024);
                //上面设定7000秒token失效,默认微信应该是两个小时7200秒
                _memoryCache.Set("wxOpenAccessToken", result.access_token, cacheEntryOptions);

                return accessToken;
            }
        }

        public async Task<LoginAccessTokenM?> GetWxAccountOpenID(string code, string role)
        {
            
            string reqUrl = $"https://api.weixin.qq.com/sns/oauth2/access_token?appid={_wxOpenID}&secret={_SendRequest}&code={code}&grant_type=authorization_code";
            var response = await _SendRequest.GetAsync(reqUrl);
            if (response == null) { return null; }
            var result = await response.Content.ReadFromJsonAsync<LoginAccessTokenM>();
            return result;

        }

        private readonly string _getUserInfo_Url = "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}";
        public async Task<WxUserInfoM?> GetWxAccountInfo( string openID)
        {
            string? accessToken =await GetAccessToken();
            if(accessToken == null) { return null; } 

            var response = await _SendRequest.GetAsync(string.Format(_getUserInfo_Url, accessToken, openID));
            var result = await response.Content.ReadFromJsonAsync<WxUserInfoM>();
            return result;
        }
        #endregion

        #region 发送模板消息类方法

        //public async Task<int> SendTemplateMsg(List<string> openidList, string first, string earnLevel, string remark)
        //{

        //    if (openidList.Count > 0)
        //    {

        //        foreach (var _openID in openidList)
        //        {

        //            //遍历所有待接受的用户openID;
        //            string? _wxAccessToken = await GetAccessToken();
        //            if (_wxAccessToken != null)
        //            {


        //            }


        //        }

        //    }
        //    return -1;

        //}


        #endregion







        //public async Task<int> SendWxNotice_SysEarning(string url, string first, string earnLevel, string remark)
        //{

        //    string[] openIdList = { "oceUrv_m_fH1bV_BV7oxPJQ99ARc", "oceUrv2z45wZuAzPX-Z7gYF7tWWA" };
        //    foreach (var item in openIdList)
        //    {
        //        var _GetToken = await GetWxAccessToken();
        //        if (_GetToken.Code != 200 || string.IsNullOrWhiteSpace(_GetToken.Content)) return 0;
        //        string token = _GetToken.Content;
        //        var sysTemp = new wxModel.TemMsgSysWarn()
        //        {

        //            touser = item,
        //            url = url,
        //            template_id = "cSw_KZe9Wp4FVdf7z_OcnBGHr7x_aMxsPzJD0QlGxLM",
        //            data = new wxModel.TemMsgSysWarnData()
        //            {

        //                first = new wxModel.tmp_first() { value = first, color = "#173177" },
        //                keyword1 = new wxModel.tmp_keyWord1() { value = "Deepl服务器异常", color = "#173177" },
        //                keyword2 = new wxModel.tmp_keyWord2() { value = DateTime.Now.ToString(), color = "#173177" },
        //                keyword3 = new wxModel.tmp_keyWord3() { value = earnLevel, color = "#173177" },
        //                remark = new wxModel.tmp_remark() { value = remark, color = "#E3170D" },
        //            }
        //        };
        //        string jsonData = JsonConvert.SerializeObject(sysTemp);

        //        var response = await _SendRequest.PostAsync(string.Format(Url_SendTemplateMsg, token), new StringContent(jsonData, Encoding.UTF8, "application/json"));
        //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //            return 1;
        //        return 0;
        //    }
        //    return 0;

        //}




        #region 微信验证类,一般只用一次
        public bool CheckSource(string signature, string timestamp, string nonce)
        {
            var str = string.Empty;
            var token = "deeplHelper7117";
            var parameter = new List<string> { token, timestamp, nonce };
            parameter.Sort();
            var parameterStr = parameter[0] + parameter[1] + parameter[2];
            var tempStr = GetSHA1(parameterStr).Replace("-", "").ToLower();
            if (tempStr == signature)
                return true;
            return false;
        }

        //SHA1加密
        public string GetSHA1(string input)
        {
            var output = string.Empty;
            var sha1 = new SHA1CryptoServiceProvider();
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var outputBytes = sha1.ComputeHash(inputBytes);
            sha1.Clear();
            output = BitConverter.ToString(outputBytes);
            return output;
        }
        #endregion
        #region  URL列表,一般不会修改.微信官方的url
        private readonly string accessToken_Url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
        private readonly string sendMsgTemplate_Url = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";

        private readonly string Url_SendTemplateMsg = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";
        #endregion
    }


}