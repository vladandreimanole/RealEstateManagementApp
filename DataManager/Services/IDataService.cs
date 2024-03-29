﻿namespace DataManager.Services;

    public interface IDataService
    {
    Task<List<User>> GetUsers();

    Task<User> CreateUserAccount(User user);

    Task<User> DeleteUserAccount(int userId);

    Task<User> UpdateUserAccount(User user);
    Task<List<Contract>> GetContractsForVerify();
    Task<Property> CreateProperty(Property property);

    Task<Property> DeleteProperty(int propertyId);

    Task<Property> UpdateProperty(Property property);

    List<Property> GetProperties();

    Task<Contract> CreateContract(Contract contract);

    Task<Contract> DeleteContract(int contractId);

    Task<Contract> UpdateContract(Contract contract);

    Task<List<Contract>> GetContracts();

    Task<User> GetUserByEmail(string email);

    Task<User> GetUserById(int userId);

    Task<UploadedImage> TransferImageToDatabase(UploadedImage uploadedImage);
    Task<Bill> TransferPdfToDatabase(Bill pdf);
    Task<Property> GetPropertyById(int propertyId);
    Task<List<UploadedImage>> GetUploadedImagesByPropertyId(int propertyId);

    Task<List<Role>> GetCurrentRoles();
    Task<List<Contract>> GetContractsByLandlordId(int landlordId);
    Task<List<Contract>> GetContractsByTenantId(int tenantId);
    Task<Contract> GetContractById(int contractId);
    Task<Chat> CreateChat(Chat chat);
    Task<Chat> GetChat(int tenantId, int landlordId);
    Task<ChatLog> CreateChatLog(ChatLog chatLog);
    Task<List<ChatLog>> GetChatLogsByChatId(int chatId);
    Task<Contract> SignContract(int contractId);
    Task<Property> UnlistProperty(int propertyId);
    Task<PropertyVisualization> CreateOrUpdatePropertyVisualization(int propertyId);
    Task<List<PropertyVisualization>> GetPropertyVisualizationsByPropertyId(int propertyId);
    }

