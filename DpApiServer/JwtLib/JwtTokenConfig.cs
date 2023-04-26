namespace DpApiServer.JwtLib
{
    public class JwtTokenConfig
    {
        public string Secret { get; set; }
        public string RefreshTokenSecret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AccessTokenExpise { get; set; }
        public int RefreshTokenExpise { get; set; }

    }
}
