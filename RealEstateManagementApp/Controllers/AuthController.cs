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
    public void Save()
    {
        try
        {
            if (HttpContext.Request.Files.AllKeys.Length > 0)
            {
                var httpPostedFile = System.Web.HttpContext.Request.Files["UploadFiles"];

                if (httpPostedFile != null)
                {
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(httpPostedFile.InputStream))
                    {
                        fileBytes = br.ReadBytes((int)httpPostedFile.InputStream.Length);
                        // bytes will be stored in variable fileBytes
                    }
                    HttpResponse Response = System.Web.HttpContext.Current.Response;
                    Response.Clear();
                    Response.ContentType = "application/json; charset=utf-8";
                    Response.StatusCode = 200;
                    Response.Status = "200 Success";
                    Response.End();
                }
            }
        }
        catch (Exception e)
        {
            HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.StatusCode = 204;
            Response.Status = "204 No Content";
            Response.StatusDescription = e.Message;
            Response.End();
        }
    }
}
