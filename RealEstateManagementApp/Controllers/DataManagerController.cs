using Microsoft.AspNetCore.Authorization;
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

    [HttpGet, Authorize]

    public async Task<List<Contract>> GetAvailableContracts()
    {
        return await _dataService.GetContracts();
    }

    [HttpGet,Authorize]

    public async Task<List<Property>> GetProperties()
    {
        
        return await _dataService.GetProperties();
    }

    [HttpGet, Authorize]

    public async Task<List<Landlord>> GetLandlords()
    {
        return await _dataService.GetLandlords();
    }

    [HttpGet, Authorize]

    public async Task<List<Tenant>> GetTenants()
    {
        return await _dataService.GetTenants();
    }

    [HttpDelete, Authorize]

    public async Task<Tenant> DeleteTenant(int tenantId)
    {
        return await _dataService.DeleteTenant(tenantId);
    }

    [HttpDelete, Authorize]

    public async Task<Property> DeleteProperty(int propertyId)
    {
        return await _dataService.DeleteProperty(propertyId);
    }

    [HttpDelete,Authorize]

    public async Task<User> DeleteUserAccount(int userId)
    {
        return await _dataService.DeleteUserAccount(userId);
    }

    [HttpDelete, Authorize]

    public async Task<Landlord> DeleteLandLor(int landLorId)
    {
        return await _dataService.DeleteLandLord(landLorId);
    }

    [HttpDelete,Authorize]

    public async Task<Contract> DeleteContract(int contractId)
    {
        return await _dataService.DeleteContract(contractId);
    }
}

