namespace RealEstateManagementApp.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IDataService _dataService;
        public ChatHub(IDataService dataService)
        {
            _dataService = dataService;
        }

        public Task JoinGroup(string chatId)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, chatId);
        }
        public Task SendMessage1(string user, string message) 
        {
            return Clients.All.SendAsync("ReceiveOne", user, message);
        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}
