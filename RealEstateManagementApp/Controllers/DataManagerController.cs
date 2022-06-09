using Microsoft.AspNetCore.Mvc;

namespace RealEstateManagementApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DataManagerController : Controller
{
    private readonly IDataService _dataService;

    public DataManagerController(IDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpGet]

    public void Test()
    {
        Console.WriteLine("");
    }
}

