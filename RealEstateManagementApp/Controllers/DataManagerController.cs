﻿using Microsoft.AspNetCore.Authorization;
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




    [HttpGet, Authorize]

    public async Task<List<Property>> GetAllProperies()
    {
        return await _dataService.GetProperties();
    }
    [HttpPost, Authorize]

    public async Task<Property> GetPropertyById(int properyId)
    {
        var props = await _dataService.GetProperties();
        return props.Where(i=>i.PropertyId == properyId).FirstOrDefault(new Property());
    }
    [HttpPost, Authorize]

    public async Task<Property> GetPropertyById([FromBody] Property prop)
    {
       
        return await _dataService.UpdateProperty(prop);
    }

    [HttpPost, Authorize]

    public async Task<User> CreateUser([FromBody] User user)
    {

        return await _dataService.CreateUserAccount(user);
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


    [HttpDelete,Authorize]

    public async Task<Contract> DeleteContract(int contractId)
    {
        return await _dataService.DeleteContract(contractId);
    }
}

