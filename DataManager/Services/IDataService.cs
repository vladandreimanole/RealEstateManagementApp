namespace DataManager.Services;

    public interface IDataService
    {
    Task<List<User>> GetUsers();

    Task<User> CreateUserAccount(User user);

    Task<User> DeleteUserAccount(int userId);

    Task<User> UpdateUserAccount(User user);

    Task<Tenant> CreateTenant(Tenant tenant);

    Task<Tenant> DeleteTenant(int tenantId);   

    Task<Tenant> UpdateTenant(Tenant tenant);

    Task<List<Tenant>> GetTenants();

    Task<Landlord> CreateLandLord(Landlord landlord);

    Task<Landlord> DeleteLandLord(int landlordId);

    Task<Landlord> UpdateLandLord(Landlord landlord);

    Task<List<Landlord>> GetLandlords();

    Task<Property> CreateProperty(Property property);

    Task<Property> DeleteProperty(int propertyId);

    Task<Property> UpdateProperty(Property property);

    Task<List<Property>> GetProperties();

    Task<Contract> CreateContract(Contract contract);

    Task<Contract> DeleteContract(int contractId);

    Task<Contract> UpdateContract(Contract contract);

    Task<List<Contract>> GetContracts();
        
    }

