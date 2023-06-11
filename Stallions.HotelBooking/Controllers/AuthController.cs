using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Stallions.HotelBooking.BLL.Interface;
using Stallions.HotelBooking.DAL.Data.Models;
using Stallions.HotelBooking.Utils.DTO;
using Stallions.HotelBooking.Utils.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Stallions.HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;

        public AuthController(UserManager<User> userManager, IRoleService roleService, IUserRoleService userRoleService, ILogger<AuthController> logger, RoleManager<Role> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _logger = logger;
            _roleService = roleService;
            _userRoleService = userRoleService;
        }

        // POST: api/Auth/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest model)
        {
            try
            {
                _logger.LogInformation("Authenticating user with the email: " + model.Email);
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var token = GetToken(authClaims);
                    _logger.LogInformation("User authenticated successfull.");
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
                _logger.LogInformation("User authentication failed.");
                return Unauthorized();
            }
            catch (Exception ex)
            {
                _logger.LogError("Unexpected Error: " + ex.Message);
                return new JsonResult(new { status = (int) ApiResponseStatus.InternalServerError, msg = ex.Message.ToString(), data = "" });
            }
        }

       // POST: api/Auth/register
       [HttpPost]
       [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserSignupRequest model)
        {
            try
            {

                var userExists = await _userManager.FindByEmailAsync(model.Email);
                if (userExists != null)
                {
                    return Conflict("User with this email already exists!");
                }

                var user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = GenerateUserName(model.FirstName, model.LastName),
                    IsActive = true,
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create user, please try again.");
                }
                else
                {
                    var roles = await _roleService.Get();
                    if (!roles.Any())
                    {
                        var roleName = RoleEnums.Admin.ToString();
                        await _roleService.Add(new Role { Name = roleName, NormalizedName = roleName.ToLower() });
                        roleName = RoleEnums.Customer.ToString();
                        await _roleService.Add(new Role { Name = roleName, NormalizedName = roleName.ToLower() });
                        roles = await _roleService.Get();
                    }
                    var selectedRole = roles.Where(x => x.Name != null && x.Id == new Guid(model.RoleId)).FirstOrDefault();
                    if(selectedRole != null)
                    {
                        var usrRole = new UserRole() { UserId = user.Id, RoleId = selectedRole.Id };
                        await _userRoleService.Add(usrRole);
                    }
             
                    var userRoles = await _userManager.GetRolesAsync(user);

                    var authClaims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }
                    var token = GetToken(authClaims);

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
            }
            catch (Exception ex)
            {
                Console.Write("Error info:" + ex.Message);
                throw;
            }
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                authClaims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signIn);

            return token;
        }

        private string GenerateUserName(string first, string last)
        {
            var userName = new string(first.Replace(" ", string.Empty).ToLower().Take(2).ToArray()) + new string(last.Replace(" ", string.Empty).ToLower().Take(2).ToArray()) + DateTime.Now.ToString("yyyyMMddHHmmss");
            return userName.ToLower();
        }
    }
}
