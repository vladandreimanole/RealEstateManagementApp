namespace DataManager.Services;

public class DataService : IDataService
{
    private readonly RealEstate_AppContext _context;

    public DataService(RealEstate_AppContext context)
    {
        _context = context;
    }

    public async Task<Contract> CreateContract(Contract contract)
    {
        _context.Contracts.Add(contract);
        await _context.SaveChangesAsync();
        return contract;
    }

    public async Task<Landlord> CreateLandLord(Landlord landlord)
    {
        _context.Landlords.Add(landlord);
        await _context.SaveChangesAsync();
        return landlord;
    }

    public async Task<Property> CreateProperty(Property property)
    {
        _context.Properties.Add(property);
        await _context.SaveChangesAsync();
        return property;
    }

    public async Task<Tenant> CreateTenant(Tenant tenant)
    {
        _context.Tenants.Add(tenant);
        await _context.SaveChangesAsync();
        return tenant;
    }

    public async Task<User> CreateUserAccount(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<Contract> DeleteContract(Contract contract)
    {
        _context.Contracts.Remove(contract);
        await _context.SaveChangesAsync();
        return contract;
    }

    public async Task<Landlord> DeleteLandLord(Landlord landlord)
    {
        _context.Landlords.Remove(landlord);
        await _context.SaveChangesAsync();
        return landlord;
    }

    public async Task<Property> DeleteProperty(Property property)
    {
        _context.Properties.Remove(property);
        await _context.SaveChangesAsync();
        return property;
    }

    public async Task<Tenant> DeleteTenant(int tenantId)
    {
        var tenantToDelete = _context.Tenants.Where(t=>t.TenantId == tenantId).FirstOrDefault();
        if(tenantToDelete is null)
            return new Tenant();

        _context.Tenants.Remove(tenantToDelete);
        await _context.SaveChangesAsync();
        return tenantToDelete;
    }

    public async Task<User> DeleteUserAccount(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<List<Contract>> GetContracts()
    {
        return await _context.Contracts.ToListAsync();
    }

    public async Task<List<Landlord>> GetLandlords()
    {
        return await _context.Landlords.ToListAsync();
    }

    public async Task<List<Property>> GetProperties()
    {
        return await _context.Properties.ToListAsync();
    }

    public async Task<List<Tenant>> GetTenants()
    {
        return await _context.Tenants.ToListAsync();
    }

    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<Contract> UpdateContract(Contract contract)
    {
        _context.Contracts.Update(contract);
        await _context.SaveChangesAsync();
        return contract;
    }

    public async Task<Landlord> UpdateLandLord(Landlord landlord)
    {
        _context.Landlords.Update(landlord);
        await _context.SaveChangesAsync();
        return landlord;
    }

    public async Task<Property> UpdateProperty(Property property)
    {
        _context.Properties.Update(property);
        await _context.SaveChangesAsync();
        return property;
    }

    public async Task<Tenant> UpdateTenant(Tenant tenant)
    {
        _context.Tenants.Update(tenant);
        await _context.SaveChangesAsync();
        return tenant;
    }

    public async Task<User> UpdateUserAccount(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }
}

