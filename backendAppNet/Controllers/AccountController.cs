using backendAppNet.DataAccess;
using backendAppNet.Entities;
using backendAppNet.Helpers;
using backendAppNet.Models.DataModels;
using backendAppNet.Models.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;


namespace backendAppNet.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        private readonly UniversityDBContext _context;

        private readonly ILogger<WeatherForecastController> _logger;


        private readonly IStringLocalizer<AccountController> _stringLocalizer;
        private readonly IStringLocalizer<SharedResource> _sharedResourceLocalizer;

        public AccountController(JwtSettings jwtSettings, UniversityDBContext context, IStringLocalizer<AccountController> stringLocalizer, IStringLocalizer<SharedResource> sharedResourceLocalizer, ILogger<WeatherForecastController> logger)
        {
            _jwtSettings = jwtSettings;
            _context = context;
            _stringLocalizer = stringLocalizer;
            _sharedResourceLocalizer = sharedResourceLocalizer;
            _logger = logger;
        }

        private IEnumerable<User> Logins = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email = "martin@gmail.com",
                Name = "Admin",
                Password = "Admin"
            },
            new User()
            {
                Id = 2,
                Email = "pepe@gmail.com",
                Name = "User1",
                Password = "pepe"
            }
        };

        [HttpPost]
        public IActionResult GetToken(UserLogins userLogins)
        {
            try
            {
                var Token = new UserTokens();
                //var Valid = Logins.Any(user => user.Name.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));
                var Valid = _context.Users.Any(user => user.Email.Equals(userLogins.UserName));

                if (Valid)
                {
                    var user = _context.Users.FirstOrDefault(user => user.Email.Equals(userLogins.UserName));
                    if (user.Password != userLogins.Password)
                    {
                        return BadRequest("Error password");
                    }
                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = user.Name,
                        EmailId = user.Email,
                        Id = user.Id,
                        GuidId = Guid.NewGuid(),
                        Roles = user.Roles

                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong Credentials");
                }
                var Welcome = _stringLocalizer.GetString("Welcome").Value ?? String.Empty;
                var responese = new
                {
                    Welcome,
                    Token
                };
                return Ok(responese);

            }catch(Exception ex)
            {
                throw new Exception("GetToken Error", ex);
            }

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }
    }
}
