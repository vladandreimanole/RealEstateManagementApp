﻿using Microsoft.AspNetCore.Authorization;
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



<<<<<<< HEAD
=======
    [HttpGet("{userId}"), Authorize]

    public async Task<Landlord> GetLandlordByUserId(int userId)
    {
        return await _dataService.GetLandlordByUserId(userId);
    }

    [HttpGet, Authorize]

    public async Task<List<Tenant>> GetTenants()
    {
        return await _dataService.GetTenants();
    }
>>>>>>> 5d862cbe963a2da1fac81ce29274c14768549eac

    [HttpGet, Authorize]

    public async Task<List<Property>> GetAllProperies()
    {
        return await _dataService.GetProperties();
    }
    [HttpGet("{properyId}")]

    public async Task<Property> GetPropertyById(int properyId)
    {
        var test = new Property();
        var props = await _dataService.GetProperties();
        return props.Where(i => i.PropertyId == properyId).FirstOrDefault(new Property());
    }

    [HttpPost, Authorize]

    public async Task<User> CreateUser([FromBody] User user)
    {

        return await _dataService.CreateUserAccount(user);
    }

<<<<<<< HEAD
=======
    [HttpPost, Authorize]

    public async Task<Tenant> CreateTenant([FromBody] Tenant tenant)
    {

        return await _dataService.CreateTenant(tenant);
    }
    [AllowAnonymous]
    [HttpPost]
    public async Task<Property> CreateProperty([FromBody] Property property)
    {
        //return new Property();
        return await _dataService.CreateProperty(property);
    }

    [HttpPost, Authorize]

    public async Task<Landlord> CreateLandLord([FromBody] Landlord landlord)
    {

        return await _dataService.CreateLandLord(landlord);
    }
>>>>>>> 5d862cbe963a2da1fac81ce29274c14768549eac
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

