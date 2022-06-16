using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateManagementApp.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DataManagerController : Controller
{
    private readonly IDataService _dataService;
    private readonly ILogger<DataManagerController> _logger;
    public DataManagerController(IDataService dataService, ILogger<DataManagerController> logger)
    {
        _dataService = dataService;
        _logger = logger;
    }

    [HttpGet, Authorize]

    public async Task<List<Contract>> GetAvailableContracts()
    {
        return await _dataService.GetContracts();
    }



 

    [HttpGet, Authorize]

    public List<Property> GetAllProperties()
    {
        return  _dataService.GetProperties();
    }
    [HttpGet("{propertyId}"), Authorize]

    public async Task<Property> GetPropertyById(int propertyId)
    {
        return await _dataService.GetPropertyById(propertyId);
    }

    [HttpGet("{propertyId}"), Authorize]

    public async Task<List<UploadedImage>> GetImagesByPropertyId(int propertyId)
    {
        return await _dataService.GetUploadedImagesByPropertyId(propertyId);
    }


    [HttpGet("{userId}"), Authorize]

    public async Task<User> GetUserById(int userId)
    {
        return await _dataService.GetUserById(userId);
    }

    [HttpPost, Authorize]

    public async Task<User> CreateUser([FromBody] User user)
    {

        return await _dataService.CreateUserAccount(user);
    }
 
    [AllowAnonymous]
    [HttpPost]
    public async Task<Property> CreateProperty([FromBody] Property property)
    {
        //return new Property();
        return await _dataService.CreateProperty(property);
    }

    [HttpDelete, Authorize]

    public async Task<Property> DeleteProperty(int propertyId)
    {
        return await _dataService.DeleteProperty(propertyId);
    }

    [HttpDelete, Authorize]

    public async Task<User> DeleteUserAccount(int userId)
    {
        return await _dataService.DeleteUserAccount(userId);
    }


    [HttpDelete, Authorize]

    public async Task<Contract> DeleteContract(int contractId)
    {
        return await _dataService.DeleteContract(contractId);
    }
}

