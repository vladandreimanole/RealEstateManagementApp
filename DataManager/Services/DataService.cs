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

    public async Task<Property> CreateProperty(Property property)
    {
        _context.Properties.Add(property);
        await _context.SaveChangesAsync();
        return property;
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


    public async Task<Property> DeleteProperty(int propertyId)
    {
        var propertyToDelete = _context.Properties.Where(x=> x.PropertyId == propertyId).FirstOrDefault();
        if (propertyToDelete is null)
            return null;
        _context.Properties.Remove(propertyToDelete);
        await _context.SaveChangesAsync();
        return propertyToDelete;
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

    public async Task<List<Property>> GetProperties()
    {
        return await _context.Properties.ToListAsync();
    }


    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
    }

    public async Task<Contract> UpdateContract(Contract contract)
    {
        _context.Contracts.Update(contract);
        await _context.SaveChangesAsync();
        return contract;
    }


    public async Task<Property> UpdateProperty(Property property)
    {
        _context.Properties.Update(property);
        await _context.SaveChangesAsync();
        return property;
    }

    public async Task<User> UpdateUserAccount(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> GetUserById(int userId)
    {
        return await _context.Users.Where(i => i.UserId == userId).FirstOrDefaultAsync();
    }

    public async Task<UploadedImage> TransferImageToDatabase(UploadedImage uploadedImage)
    {
        _context.UploadedImages.Add(uploadedImage);
        await _context.SaveChangesAsync();
        return uploadedImage;
    }
}

