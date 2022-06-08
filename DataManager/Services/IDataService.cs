namespace DataManager.Services;

    public interface IDataService
    {
    Task<IEnumerable<User>> GetUsers();

    Task<User> CreateUserAccount(User user);

    Task<User> DeleteUserAccount(User user);

    Task<User> UpdateUserAccount(User user);

    Task<Tenant> CreateTenant(Tenant tenant);

    Task<Tenant> DeleteTenant(Tenant tenant);   

    Task<Tenant> UpdateTenant(Tenant tenant);

    Task<IEnumerable<Tenant>> GetTenants();

    Task<Landlord> CreateLandLord(Landlord landlord);

    Task<Landlord> DeleteLandLord(Landlord landlord);

    Task<Landlord> UpdateLandLord(Landlord landlord);

    Task<IEnumerable<Landlord>> GetLandlords();

    Task<Property> CreateProperty(Property property);

    Task<Property> DeleteProperty(Property property);

    Task<Property> UpdateProperty(Property property);

    Task<IEnumerable<Property>> GetProperties();

    Task<Contract> CreateContract(Contract contract);

    Task<Contract> DeleteContract(Contract contract);

    Task<Contract> UpdateContract(Contract contract);

    Task<IEnumerable<Contract>> GetContracts();
        
    }

