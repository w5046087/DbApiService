using System.Text;
using System.Security.Cryptography;
using System.Net.Http.Json;
using Newtonsoft.Json;
using DpApiServer.Global.RsMsg;
using Microsoft.Extensions.Caching.Memory;

namespace DpApiServer.WeiXinLib
{
    public class WxDetail
    {
        private readonly HttpLib.SendRequest _SendRequest;
        private readonly IMemoryCache _memoryCache;
        public WxDetail(HttpLib.SendRequest sendRequest,IMemoryCache memoryCache)
        {
            _SendRequest = sendRequest;
            _memoryCache = memoryCache;
        }
        private string wxId = "wxe32d968adde60610";
        private string wxSKey = "66c8a43232d43a60acd4700c867662b2";
        private string Url_AccessToken
        {
            get
            {
                return $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={wxId}&secret={wxSKey}";
            }
        }
        private readonly string Url_SendTemplateMsg = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";
        public async Task<RsMsgSimple> GetWxAccessToken() {
            if (_memoryCache.TryGetValue("wxAccessToken", out string? accessToken))
            {
                return new RsMsgSimple(200,accessToken);

            }
            else {
                var response = await _SendRequest.GetAsync(Url_AccessToken);
                var result = await response.Content.ReadFromJsonAsync<wxModel.AccessTokenModel>();
                if (result == null || string.IsNullOrWhiteSpace(result.access_token)) return new RsMsgSimple(-1, "获取accessToken失败");

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(7000))
                        .SetPriority(CacheItemPriority.Normal)
                        .SetSize(1024);
                _memoryCache.Set("wxAccessToken",result.access_token, cacheEntryOptions);
                return new RsMsgSimple(200, result.access_token);
            }
            
        }
        public async Task<int> SendWxNotice_SysEarning(string url, string first, string earnLevel, string remark) {
       
            string[] openIdList ={ "oceUrv_m_fH1bV_BV7oxPJQ99ARc", "oceUrv2z45wZuAzPX-Z7gYF7tWWA" };
            foreach (var item in openIdList) {
                var _GetToken = await GetWxAccessToken();
                if (_GetToken.Code != 200 || string.IsNullOrWhiteSpace(_GetToken.Content)) return 0;
                string token = _GetToken.Content;
                var sysTemp = new wxModel.TemMsgSysWarn()
                {

                    touser = item,
                    url = url,
                    template_id = "cSw_KZe9Wp4FVdf7z_OcnBGHr7x_aMxsPzJD0QlGxLM",
                    data = new wxModel.TemMsgSysWarnData()
                    {

                        first = new wxModel.tmp_first() { value = first, color = "#173177" },
                        keyword1 = new wxModel.tmp_keyWord1() { value = "Deepl服务器异常", color = "#173177" },
                        keyword2 = new wxModel.tmp_keyWord2() { value = DateTime.Now.ToString(), color = "#173177" },
                        keyword3 = new wxModel.tmp_keyWord3() { value = earnLevel, color = "#173177" },
                        remark = new wxModel.tmp_remark() { value = remark, color = "#E3170D" },
                    }
                };
                string jsonData = JsonConvert.SerializeObject(sysTemp);

                var response = await _SendRequest.PostAsync(String.Format(Url_SendTemplateMsg, token), new StringContent(jsonData, Encoding.UTF8, "application/json"));
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return 1;
                return 0;
            }
            return 0;
           
        }
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
            var inputBytes = UTF8Encoding.UTF8.GetBytes(input);
            var outputBytes = sha1.ComputeHash(inputBytes);
            sha1.Clear();
            output = BitConverter.ToString(outputBytes);
            return output;
        }

    }
}
