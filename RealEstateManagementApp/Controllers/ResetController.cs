
using Microsoft.AspNetCore.Authorization;
using PassResetManager;

namespace RealEstateManagementApp.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ResetController : Controller
{
    private readonly IDataService _dataService;

    private readonly IResetPasswordManager _passwordManager;
    private readonly ILogger<ResetController> _logger;
    public ResetController(IResetPasswordManager passwordManager, ILogger<ResetController> logger, IDataService dataService)
    {
        _passwordManager = passwordManager;
        _logger= logger;
    }


    [AllowAnonymous]
    [HttpGet]
    public async Task<bool> SendResetEmail(string email)
    {

        return await _passwordManager.SendResetPasswordForUser(email);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<bool> VerifyAndUpdatePass(User user)
    {

        var isTokenOk= await _passwordManager.VerifyResetTokenForUser(user?.Email,user?.PassResetToken);

        if (isTokenOk)
        {
            await _dataService.UpdateUserAccount(user);
            return true;
        }
        return false;
    }

}

