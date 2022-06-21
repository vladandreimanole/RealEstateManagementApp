using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PassResetManager;

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
    [AllowAnonymous]
    [HttpGet]

    public async Task<List<Role>> GetCurrentRoles()
    {
        return await _dataService.GetCurrentRoles();
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

    [HttpGet("{landlordId}"), Authorize]

    public async Task<List<Contract>> GetContractsByLandlordId(int landlordId)
    {
        return await _dataService.GetContractsByLandlordId(landlordId);
    }

    [HttpGet("{tenantId}"), Authorize]

    public async Task<List<Contract>> GetContractsByTenantId(int tenantId)
    {
        return await _dataService.GetContractsByTenantId(tenantId);
    }

    [HttpGet("{propertyId}"), Authorize]

    public async Task<List<UploadedImage>> GetImagesByPropertyId(int propertyId)
    {
        return await _dataService.GetUploadedImagesByPropertyId(propertyId);
    }
    [HttpGet("{contractId}"), Authorize]
    public async Task<Contract> GetContractById(int contractId)
    {
        return await _dataService.GetContractById(contractId);
    }

    [HttpGet("{userId}"), Authorize]

    public async Task<User> GetUserById(int userId)
    {
        return await _dataService.GetUserById(userId);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<User> CreateUser( User user)
    {

        return await _dataService.CreateUserAccount(user);
    }
 
    [HttpPost, Authorize]
    public async Task<Property> CreateProperty([FromBody] Property property)
    {
        //return new Property();
        return await _dataService.CreateProperty(property);
    }

    [HttpPost, Authorize]
    public async Task<Contract> CreateContract([FromBody] Contract contract)
    {
        //return new Property();
        return await _dataService.CreateContract(contract);
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

