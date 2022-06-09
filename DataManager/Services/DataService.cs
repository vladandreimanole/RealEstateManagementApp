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

    public async Task<Contract> DeleteContract(int contractId)
    {
        var contractToDelete = _context.Contracts.Where(x => x.ContractId == contractId).FirstOrDefault();
        if (contractToDelete is null)
            return null;
        _context.Contracts.Remove(contractToDelete);
        await _context.SaveChangesAsync();
        return contractToDelete;
    }

    public async Task<Landlord> DeleteLandLord(int landlordId)
    {
        var landlordToDelete = _context.Landlords.Where(x => x.LandlordId == landlordId).FirstOrDefault();
        if (landlordToDelete is null)
            return null;
        _context.Landlords.Remove(landlordToDelete);
        await _context.SaveChangesAsync();
        return landlordToDelete;
    }

    public async Task<Property> DeleteProperty(int propertyId)
    {
        var propertyToDelete = _context.Properties.Where(x=> x.PropertyId == propertyId).FirstOrDefault();
        if (propertyToDelete is null)
            return null;
        _context.Properties.Remove(propertyToDelete);
        await _context.SaveChangesAsync();
        return propertyToDelete;
    }

    public async Task<Tenant> DeleteTenant(int tenantId)
    {
        var tenantToDelete = _context.Tenants.Where(t=>t.TenantId == tenantId).FirstOrDefault();
        if (tenantToDelete is null)
            return null;

        _context.Tenants.Remove(tenantToDelete);
        await _context.SaveChangesAsync();
        return tenantToDelete;
    }

    public async Task<User> DeleteUserAccount(int userId)
    {
        var userToDelete = _context.Users.Where(x => x.UserId == userId).FirstOrDefault();
        if (userToDelete is null)
            return null;
        _context.Users.Remove(userToDelete);
        await _context.SaveChangesAsync();
        return userToDelete;
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

