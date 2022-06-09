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

    public async Task<List<Contract>> GetAvailableContracts()
    {
        var result = await _dataService.GetContracts();
        return result.ToList();
    }

    [HttpGet]

    public async Task<List<Property>> GetProperties()
    {
        
        return await _dataService.GetProperties();
    }

    [HttpGet]

    public async Task<List<Landlord>> GetLandlords()
    {
        return await _dataService.GetLandlords();
    }

    [HttpGet]

    public async Task<List<Tenant>> GetTenants()
    {
        return await _dataService.GetTenants();
    }
}

