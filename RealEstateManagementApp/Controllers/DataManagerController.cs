using Microsoft.AspNetCore.Mvc;

namespace RealEstateManagementApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DataManagerController : Controller
{
    private readonly IDataService _dataService;
    private readonly ILogger<DataManagerController> _logger;
    public DataManagerController(IDataService dataService, ILogger<DataManagerController> logger)
    {
        _dataService = dataService;
        _logger = logger;
    }

    [HttpGet]

    public void Test()
    {
        Console.WriteLine("");
    }
}

