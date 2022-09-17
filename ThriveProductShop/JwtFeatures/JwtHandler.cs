using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ProductShop.Identity;

namespace ThriveProductShop.JwtFeatures
{
	public class JwtHandler
	{
		private readonly IConfiguration _configuration;
		private readonly IConfigurationSection _jwtSettings;
		private readonly UserManager<ApplicationUser> _userManager;

		public JwtHandler(IConfiguration configuration,  UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
			_configuration = configuration;
			_jwtSettings = _configuration.GetSection("JwtSettings");
		}

		public SigningCredentials GetSigningCredentials()
		{
			var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("SecretKey").Value);
			var secret = new SymmetricSecurityKey(key);

			return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
		}

		public async Task<List<Claim>> GetClaims(ApplicationUser user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Email)
			};
			var roles = await _userManager.GetRolesAsync(user);
			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}
			return claims;
		}

		public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
		{
			var tokenOptions = new JwtSecurityToken(
				issuer: _jwtSettings["ValidIssuer"],
				audience: _jwtSettings["ValidAudience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["expiryInMinutes"])),
				signingCredentials: signingCredentials);

			return tokenOptions;
		}
	}
}