using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UndyingWorld.Web.Models;
using UndyingWorld.Web.Services.Data;
using UndyingWorld.Web.Services.Impl.Data;

namespace UndyingWorld.Web.Api.Jwt
{
	public class JwtManagerRepository : IJwtManagerRepository
	{
		private readonly IConfiguration _configuration;
		private readonly IPlayerService _playerService;

        public JwtManagerRepository(IServiceProvider serviceProvider, IConfiguration configuration, IPlayerService playerService)
        {
            _configuration = configuration;
            _playerService = playerService;
		}

		public JwtToken Authenticate(User user)
		{
			if (!_playerService.IsUser(user.Nickname, user.Password))
				return null;
            
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Nickname)
				}),
				Expires = DateTime.UtcNow.AddMinutes(120),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return new JwtToken { Token = tokenHandler.WriteToken(token) };

		}
	}
}
