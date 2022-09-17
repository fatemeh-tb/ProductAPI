using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductShop.Identity;
using ProductShop.models.UserDomain;
using ThriveProductShop.JwtFeatures;
using LoginModel = ProductShop.models.UserDomain.LoginModel;
using RegisterModel = ProductShop.models.UserDomain.RegisterModel;

namespace ProductShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly JwtHandler _jwtHandler;

        public AuthenticationController(UserManager<ApplicationUser> userManager,
            IConfiguration configuration, JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _configuration = configuration;
            _jwtHandler = jwtHandler;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();
                       
            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Name
            };
            
            var result = await _userManager.CreateAsync(user, model.Password);
            
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegisterResponse { Errors = errors });
            }
            
            await _userManager.AddToRoleAsync(user, "Fatemeh");

            return StatusCode(200);
        }

        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var checkPassword = await  _userManager.CheckPasswordAsync(user, model.Password);
            if (user == null || !checkPassword)
                return Unauthorized(new LoginResponse { errorMessage  = "Invalid Authentication" });
            
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = await _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            
            return Ok(new LoginResponse { isAuthSuccessful = true, token = token});
        }
        
        
        [HttpGet("admin")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Privacy()
        {
            var claims = User.Claims
                .Select(c => new { c.Type, c.Value })
                .ToList();
            return Ok(claims);
        }
    }
}