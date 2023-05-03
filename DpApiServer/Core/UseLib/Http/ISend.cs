namespace DpApiServer.Core.UseLib.Http
{
    public interface ISend
    {
         Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, HttpContent httpContent);

    }
}
