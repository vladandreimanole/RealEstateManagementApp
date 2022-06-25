
namespace RealEstateManagementApp.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IDataService _dataService;
        public ChatController(IHubContext<ChatHub> hubContext, IDataService dataService)
        {
            _hubContext = hubContext;
            _dataService = dataService;
        }

        [Route("send")]                                           //path looks like this: https://localhost:44379/api/chat/send
        [HttpPost]
        public IActionResult SendRequest([FromBody] MessageDto msg)
        {
            var chatMessage = new ChatLog
            {
                ChatId = Int32.Parse(msg.chatId),
                ChatMessage = msg.msgText,
                SentTime = (DateTime)msg.sentTime,
                SentByUserId = msg.sentByUserId
            };
            _dataService.CreateChatLog(chatMessage);
            _hubContext.Clients.Group(msg.chatId).SendAsync("ReceiveOne", msg.sentByUserId, msg.msgText);
            return Ok();
        }

    }
}
