using Business.Core;
using Business.Model;
using Business.Model.ModelView;
using Data.Entity;
using Data.Repository.Model;
using Infra;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Business
{
    public class LoginBusiness : CommonBusiness, ILoginBusiness
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginBusiness(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<LoginResponseModelView?> Authenticate(LoginModelView loginModelView)
        {
            var usuario = await _usuarioRepository.GetByLogin(loginModelView.Login);

            if (usuario == null)
            {
                Mensagem = "Login não encontrado";
                return await Task.FromResult<LoginResponseModelView?>(null);
            }

            if (!VerifyPasswordHash(loginModelView.Senha, usuario!.Senha, out string erro))
            {
                Mensagem = erro;
                return await Task.FromResult<LoginResponseModelView?>(null);
            }

            return GenerateToken(usuario);
        }

        private static bool VerifyPasswordHash(string senha, string hash, out string erro)
        {
            erro = string.Empty;

            var senhaValidada = Utils.VerifyHash(senha, hash) || Utils.VerifyHash(senha.ToUpper(), hash);

            if (!senhaValidada)
            {
                erro = "Senha inválida";
                return false;
            }

            return true;
        }

        private LoginResponseModelView GenerateToken(Usuario usuario)
        {
            var identity = new ClaimsIdentity(new GenericIdentity(usuario.IdUsuario.ToString(), "Login"));

            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")));
            identity.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, usuario.IdUsuario.ToString()));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, usuario.Email));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.GivenName, usuario.Nome));

            var dataCriacao = DateTime.UtcNow;
            var dataExpiracao = dataCriacao.AddMinutes(120);

            TokenConfigurations.BuidCredentials();

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                SigningCredentials = TokenConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });

            return new LoginResponseModelView
            {
                Authenticated = true,
                AccessToken = handler.WriteToken(securityToken), 
                Created = dataCriacao,
                Expiration = dataExpiracao
            };
        }
    }
}
