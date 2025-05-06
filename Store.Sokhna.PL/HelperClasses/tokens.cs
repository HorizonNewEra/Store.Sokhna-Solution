using Store.Sokhna.DAL.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace Store.Sokhna.PL.HelperClasses
{
	public class TokensClass
	{
		private readonly IConfiguration configuration;

		public TokensClass(IConfiguration configuration)
        {
			this.configuration = configuration;
		}
  //      public string createtoken(Users users)
		//{
		//	var AuthClaims = new List<Claim>()
		//	{
		//		new Claim(ClaimTypes.GivenName,users.FullName),
		//		new Claim(ClaimTypes.Role,users.Job),
		//		new Claim(ClaimTypes.SerialNumber,users.SSN),
		//		new Claim(ClaimTypes.IsPersistent,users.RememberMe.ToString()),

		//	};
		//	var AuthKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
		//	var token = new JwtSecurityToken(
		//		issuer: configuration["Jwt:Issuer"],
		//		audience: configuration["Jwt:Audience"],
		//		expires: DateTime.Now.AddDays(double.Parse(configuration["Jwt:DurationInDays"])),
		//		claims: AuthClaims,
		//		signingCredentials: new SigningCredentials(AuthKey, SecurityAlgorithms.HmacSha256Signature)
		//	);
		//	return new JwtSecurityTokenHandler().WriteToken(token);
		//}
	}
}
