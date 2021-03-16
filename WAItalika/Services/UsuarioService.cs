using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WAItalika.JWA;

namespace WAItalika.Models.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppSettings _appSettings;

        public UsuarioService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }

        public UsuarioResponse Response(AuthRequest auth)
        {
            UsuarioResponse usuarioResponse = new UsuarioResponse();
            using (var db = new italika_dbContext())
            {
                string sPass = Encrypt.GetSha256(auth.contraseña);

                var usuario = db.Usuarios.Where(db => db.NombreUsuario == auth.nombre_usuario && db.Contraseña == auth.contraseña).FirstOrDefault();

                if (usuario == null) return null;
                usuarioResponse.Nombre_Usuario = usuario.NombreUsuario;
                usuarioResponse.Token = GetToken(usuario);
            }
            return usuarioResponse;
        }

        private string GetToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Name, usuario.NombreUsuario)
                    }),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
