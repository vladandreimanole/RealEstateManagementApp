namespace DataManager.Services;

    public interface IDataService
    {

    Task CreateUserAccount(User user);

    Task DeleteUserAccount(User user);

    Task UpdateUserAccount(User user);

    Task CreateTenant(Tenant tenant);

    Task DeleteTenant(Tenant tenant);   

    Task UpdateTenant(Tenant tenant);

    Task CreateLandLord(Landlord landlord);

    Task DeleteLandLord(Landlord landlord);

    Task UpdateLandLord(Landlord landlord);

    Task CreateProperty(Property property);

    Task DeleteProperty(Property property);

    Task UpdateProperty(Property property);

    Task CreateContract(Contract contract);

    Task DeleteContract(Contract contract);
        
    }

