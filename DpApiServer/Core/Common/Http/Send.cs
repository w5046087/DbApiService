namespace DpApiServer.Core.Common.Http
{
    public class Send:ISend
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public Send(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var response = await client.GetAsync(url);
                return response;
            }
        }
        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent httpContent)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var response = await client.PostAsync(url, httpContent);
                return response;
            }
        }
    }
}
