using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserDatabase.Api.Models;
using System.Threading.Tasks;
using System;
using UserDatabase.Api.Models.Authentication.Login;
using UserDatabase.Api.Models.Authentication.Signup;

namespace UserDatabase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly IConfiguration _configuration;
        private SignInManager<IdentityUser> signInManager;

        public AuthenticationController(UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

            _configuration = configuration;
            this.signInManager = signInManager;
        }

        [HttpPost]

        public async Task<IActionResult> Register([FromBody] Registeruser registerUser)
        {
            

            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new response { Status = "Error", Message = " user alredy exists !" });
            }

            IdentityUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.Username,
            };
            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                return StatusCode(StatusCodes.Status201Created,
                     new response { Status = "sucess", Message = " user created sucessfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 new response { Status = "Error", Message = " user created failed  !" });
            }
        }




        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user != null)
            {
                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (signInResult.Succeeded)
                {
                    // Authentication successful
                    return Ok(new { Message = "Login successful" });
                }
            }

            // Authentication failed
            return BadRequest(new { Message = "Email and password do not match" });
    }

    }
}
