
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
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
        private string? GeneratorToken(string username, string role,int expirseMinte)
        {
            try
            {
                var claims = new Claim[]{
            new Claim(
                ClaimTypes.Name,username
            ),
            new Claim(
                ClaimTypes.Role,role
            ),
            new Claim("Jit",Guid.NewGuid().ToString())
           };
                var secretKey = System.Text.Encoding.UTF8.GetBytes(_jwtTokenConfig.Secret);

                var jwtToken = new JwtSecurityToken(
                   issuer: _jwtTokenConfig.Issuer,
                    audience: _jwtTokenConfig.Audience,
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(expirseMinte),
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(secretKey),
                        SecurityAlgorithms.HmacSha256Signature
                    )
                );
                return new JwtSecurityTokenHandler().WriteToken(jwtToken);
            }
            catch (Exception e)
            {

                return null;
            }
        }
        public string? CreateLoginTokenJson(string userName,string role) { 
        
            string? access_token=GeneratorToken(userName,role,_jwtTokenConfig.AccessTokenExpise);
            string? refresh_token = GeneratorToken(userName, role,_jwtTokenConfig.RefreshTokenExpise);

            if (access_token != null && refresh_token != null)
            {
                return JsonConvert.SerializeObject(new { 
                
                    access_token=access_token,
                    refresh_token=refresh_token,  
                });
            }
            return null;

        }
    }
}