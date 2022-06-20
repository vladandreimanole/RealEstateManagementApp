
using Microsoft.AspNetCore.Authorization;
using PassResetManager;

namespace RealEstateManagementApp.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ResetController : Controller
{
    private readonly IResetPasswordManager _passwordManager;
    private readonly ILogger<ResetController> _logger;
    public ResetController(IResetPasswordManager passwordManager, ILogger<ResetController> logger)
    {
        _passwordManager = passwordManager;
        _logger= logger;
    }


    [AllowAnonymous]
    [HttpGet]
    public async Task SendResetEmail(string email)
    {

        await _passwordManager.SendResetPasswordForUser(email);
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<bool> VerifyToken(string email, string token)
    {

        return await _passwordManager.VerifyResetTokenForUser(email,token);
    }
}

