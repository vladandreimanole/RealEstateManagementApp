namespace DataManager.Services;

    public interface IDataService
    {
    Task<List<User>> GetUsers();

    Task<User> CreateUserAccount(User user);

    Task<User> DeleteUserAccount(int userId);

    Task<User> UpdateUserAccount(User user);

    Task<Property> CreateProperty(Property property);

    Task<Property> DeleteProperty(int propertyId);

    Task<Property> UpdateProperty(Property property);

    Task<List<Property>> GetProperties();

    Task<Contract> CreateContract(Contract contract);

    Task<Contract> DeleteContract(int contractId);

    Task<Contract> UpdateContract(Contract contract);

    Task<List<Contract>> GetContracts();

    Task<User> GetUserByEmail(string email);

    Task<User> GetUserById(int userId);

    Task<UploadedImage> TransferImageToDatabase(UploadedImage uploadedImage);

    }

