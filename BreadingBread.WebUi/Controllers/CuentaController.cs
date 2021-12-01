using BreadingBread.Application.UseCases.Usuarios.Commands.CreateUsuario;
using BreadingBread.Application.UseCases.Usuarios.Commands.InvalidaToken;
using BreadingBread.Application.UseCases.Usuarios.Commands.RecuperaPassword;
using BreadingBread.Application.UseCases.Usuarios.Commands.RecuperaPasswordGeneraToken;
using BreadingBread.Application.UseCases.Usuarios.Commands.RefreshCredentials;
using BreadingBread.Application.UseCases.Usuarios.Queries.GetUsuarioLogin;
using BreadingBread.Domain.Enums;
using BreadingBread.WebUi.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.WebUi.Controllers
{
    [AllowAnonymous]
    public class CuentaController : BaseController
    {
        private readonly AuthOptions authOptions;

        public CuentaController(IOptions<AuthOptions> options)
        {
            this.authOptions = options.Value;
        }

        [HttpPost]
        public async Task<ActionResult<IngresarResponse>> Ingresar([FromBody] GetUserLoginQuery query)
        {
            var response = await Mediator.Send(query);
            // authentication successful so generate jwt token
            var token = GenerateToken(new Claim[] {
                new Claim(ClaimTypes.Name, response.UserName),
                new Claim(ClaimTypes.NameIdentifier, response.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, response.UserType.ToString()),
            });
            return Ok(new IngresarResponse
            {
                User = new UserInfo
                {
                    UserType = response.UserType,
                    IdUser = response.IdUsuario,
                    UserName = response.UserName,
                    RefreshToken = response.RefreshToken
                },
                Token = token.token,
                RefreshToken = response.RefreshToken,
                ExpirationDate = token.expirationDate
            });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IngresarResponse>> RefreshCredentials([FromBody] RefreshCredentialsCommand query)
        {
            var principal = GetPrincipalFromExpiredToken(query.Token);

            var response = await Mediator.Send(query);
            var token = GenerateToken(principal.Claims);

            return Ok(new IngresarResponse
            {
                Token = token.token,
                User = new UserInfo
                {
                    RefreshToken = response.RefreshToken,
                    IdUser = response.IdUsuario,
                    UserName = response.UserName,
                    UserType = response.UserType
                },
                ExpirationDate = token.expirationDate,
                RefreshToken = response.RefreshToken
            });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InvalidaTokenResponse>> InvalidaToken([FromBody] InvalidaTokenCommand query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<RecuperaPasswordGeneraTokenResponse>> RecuperaPasswordGeneraToken([FromBody] RecuperaPasswordGeneraTokenCommand query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<RecuperaPasswordResponse>> RecuperaPassword([FromBody] RecuperaPasswordCommand query)
        {
            return Ok(await Mediator.Send(query));
        }

        private (string token, DateTime expirationDate) GenerateToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authOptions.Secret));

            var jwt = new JwtSecurityToken(issuer: "BreadingBread",
                audience: "Everyone",
                claims: claims, //the user's claims, for example new Claim[] { new Claim(ClaimTypes.Name, "The username"), //... 
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddSeconds(authOptions.DurationJwtTokenInSeconds),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return (new JwtSecurityTokenHandler().WriteToken(jwt), jwt.ValidTo); //the method is called WriteToken but returns a string
        }

        [HttpHead]
        public ActionResult Ping()
        {
            return Ok();
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authOptions.Secret)),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        public class IngresarResponse
        {
            public UserInfo User { get; set; }
            public string Token { get; set; }
            public string RefreshToken { get; set; }
            public UserType UserType { get; set; }
            public DateTime ExpirationDate { get; set; }

        }

        public class UserInfo
        {
            public int IdUser { get; set; }
            public string UserName { get; set; }
            public UserType UserType { get; set; }
            public string RefreshToken { get; set; }
        }

        [HttpPost]
        public async Task<ActionResult<CreateUsuarioResponse>> CreateUser([FromBody] CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}