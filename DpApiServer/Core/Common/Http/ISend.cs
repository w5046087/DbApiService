namespace DpApiServer.Core.Common.Http
{
    public interface ISend
    {
         Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, HttpContent httpContent);
    }
}
