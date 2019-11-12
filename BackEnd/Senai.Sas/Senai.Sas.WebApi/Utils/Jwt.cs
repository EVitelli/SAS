using Microsoft.IdentityModel.Tokens;
using Senai.Sas.Infra.Core.ViewModels;
using Senai.Sas.Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.Sas.WebApi.Utils
{
    public static class Jwt
    {
        public static string GerarToken(Usuarios usuario)
        {
            //Define os dados que serão fornecidos no token - PayLoad
            var claims = new[]
            {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.UsuarioId.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Permissao.Nome),
                };

            // Chave de acesso do token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("sas-chave-autenticacao"));

            //Credenciais do Token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Gera o token
            var token = new JwtSecurityToken(
                issuer: "Sas.WebApi",
                audience: "Sas.WebApi",
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static long TokenId(ClaimsPrincipal token)
        {
            long usuarioId = Convert.ToInt32(token.FindFirst(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return usuarioId;
        }

        public static string TokenPermissao(ClaimsPrincipal token)
        {
            string permissao = token.FindFirst(c => c.Type == ClaimTypes.Role).Value;
            return permissao;
        }

    }
}
