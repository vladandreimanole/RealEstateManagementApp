using System.Web;
namespace RealEstateManagementApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IDataService _dataService;
    private readonly ILogger<AuthController> _logger;

    private readonly IOptionsMonitor<AuthentificationOptionsMonitor> _optionsMonitor;
    public AuthController(IDataService dataService, ILogger<AuthController> logger, IOptionsMonitor<AuthentificationOptionsMonitor> optionsMonitor)
    {
        _logger = logger;
        _dataService = dataService;
        _optionsMonitor = optionsMonitor;
    }
    [HttpPost("login")]
    public IActionResult Login(AuthenticateRequest model)
    {

        if (String.IsNullOrEmpty(model.email) || model.password is null)
        {
            return BadRequest("Invalid client request");
        }
        var realUserFromDb = _dataService.GetUserByEmail(model.email).ConfigureAwait(false).GetAwaiter().GetResult();

        if (realUserFromDb is null)
        {
            return BadRequest("Account does not exist");
        }
        if (String.Equals(model.email, realUserFromDb.Email) && String.Equals(model.password, realUserFromDb.Password))
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_optionsMonitor.CurrentValue.JwtToken));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                //to do configurable urls
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: new List<Claim>(),                
                expires: DateTime.Now.AddMinutes(_optionsMonitor.CurrentValue.JwtTokenExpirationTimeMinutes),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new AuthenticatedResponse { Token = tokenString, Email = realUserFromDb.Email});
        }
        return Unauthorized();
    }

    [AcceptVerbs("Post")]
    public IActionResult TestUpload(object model)
    {
        var test = HttpContext.Request;
        return Ok(null);
    }

}
