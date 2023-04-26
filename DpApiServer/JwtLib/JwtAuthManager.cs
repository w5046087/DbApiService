
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using DpApiServer.Global.RsMsg;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace DpApiServer.JwtLib
{
    public class JwtAuthManager
    {
        private readonly JwtTokenConfig _jwtTokenConfig;
        public JwtAuthManager(JwtTokenConfig jwtConfig)
        {
            this._jwtTokenConfig = jwtConfig;
        }
        public async Task<JwtAuthResult> GenerateLoginToken(string username, string role)
        {

            var claims = new Claim[]{
            new Claim(
                ClaimTypes.Name,username
            ),
            new Claim(
                ClaimTypes.Role,role
            )
           };
            return await GenerateJwtAuth(claims,true);
        }

        public async Task<RsMsgSimple> RefresnUserToken(string _refreshToken)
        {
            var (principal, jwtToken) = DecodeJwtToken(_refreshToken);
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            {
                return new RsMsgSimple(-1, "Invalid Token");
            }
            var username = principal.Claims?.FirstOrDefault(t => t.Type == ClaimTypes.Name)?.Value;
            var client_id = principal.Claims?.FirstOrDefault(t => t.Type == ClaimTypes.Role)?.Value;

            if (string.IsNullOrWhiteSpace(client_id) || string.IsNullOrWhiteSpace(username))
            {
                return new RsMsgSimple(-1, "Invalid Token");
            }
            var claims = new Claim[]{
            new Claim(
                ClaimTypes.Name,username
            ),
            new Claim(
                ClaimTypes.Role,client_id
            )
           };
            var result = await GenerateJwtAuth(claims, false);
            return new RsMsgSimple(200, JsonConvert.SerializeObject(result));

            //这里有点问题,可以加入根据时间限制refreshtoken的使用频率.

        }
        private Task<JwtAuthResult> GenerateJwtAuth(Claim[] claims, bool IsIncludeRefreshToken=false)
        {
            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);
            var secretKey = System.Text.Encoding.ASCII.GetBytes(_jwtTokenConfig.Secret);
            var RefreshSecretKey = System.Text.Encoding.ASCII.GetBytes(_jwtTokenConfig.RefreshTokenSecret);

            //创建accessToken
            var jwtToken = new JwtSecurityToken(
                _jwtTokenConfig.Issuer,
                shouldAddAudienceClaim ? _jwtTokenConfig.Audience : string.Empty,
                claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtTokenConfig.AccessTokenExpise),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature
                )
            );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            //创建refreshToken
            if (IsIncludeRefreshToken)
            {
                var jwRefreshToken = new JwtSecurityToken(
                    _jwtTokenConfig.Issuer,
                    shouldAddAudienceClaim ? _jwtTokenConfig.Audience : string.Empty,
                    claims,
                    expires: DateTime.UtcNow.AddMonths(_jwtTokenConfig.RefreshTokenExpise),
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(RefreshSecretKey),
                        SecurityAlgorithms.HmacSha256Signature
                    )
                );
                var refreshToken = new JwtSecurityTokenHandler().WriteToken(jwRefreshToken);
                return Task.FromResult(new JwtAuthResult()
                {
                    access_token = accessToken,
                    refresh_toke = refreshToken,
                    expise_in = _jwtTokenConfig.AccessTokenExpise
                });
            }
            else {
                return Task.FromResult(new JwtAuthResult()
                {
                    access_token = accessToken,
                    expise_in = _jwtTokenConfig.AccessTokenExpise
                });
            }

           
        } 
            //返回模型
        (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string _token)
        {
            if (string.IsNullOrWhiteSpace(_token))
            {
                throw new SecurityTokenException();
            }
            var principal = new JwtSecurityTokenHandler().ValidateToken(_token,
            new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtTokenConfig.Issuer,
                ClockSkew = TimeSpan.FromMinutes(1),
                ValidateAudience = true,
                ValidAudience = _jwtTokenConfig.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(_jwtTokenConfig.RefreshTokenSecret))

            }, out var validatedToken);
            return (principal, validatedToken as JwtSecurityToken);
        }
    }
}
