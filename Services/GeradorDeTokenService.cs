using System.Text;
using managemoney.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace managemoney.Services
{
    public class GeradorDeTokenService
    {
        public string GerarToken(UsuarioModel usuario)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id)
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asDASD@#%#SDASPOAOSD@#!213213asdasDASDASDASDSAd"));
            
            var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}