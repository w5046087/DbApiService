namespace DpApiServer.JwtLib
{
    public class JwtAuthResult
    {
        public string? access_token { get; set; }
        public string? refresh_toke { get; set; }
        public int expise_in { get; set; }
    }
}
