namespace DataManager.Services;

public class DataService : IDataService
{
    private readonly RealEstate_AppContext _context;

    public DataService(RealEstate_AppContext context)
    {
        _context = context;
    }

    public Task CreateContract(Contract contract)
    {
        throw new NotImplementedException();
    }

    public Task CreateLandLord(Landlord landlord)
    {
        throw new NotImplementedException();
    }

    public Task CreateProperty(Property property)
    {
        throw new NotImplementedException();
    }

    public Task CreateTenant(Tenant tenant)
    {
        throw new NotImplementedException();
    }

    public Task CreateUserAccount(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteContract(Contract contract)
    {
        throw new NotImplementedException();
    }

    public Task DeleteLandLord(Landlord landlord)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProperty(Property property)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTenant(Tenant tenant)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAccount(User user)
    {
        throw new NotImplementedException();
    }

    public Task UpdateLandLord(Landlord landlord)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProperty(Property property)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTenant(Tenant tenant)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserAccount(User user)
    {
        throw new NotImplementedException();
    }
}

