﻿
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

        [Route("send")]
        [HttpPost]
        public IActionResult SendRequest([FromBody] MessageDto msg)
        {
            var chatMessage = new ChatLog
            {
                ChatId = Convert.ToInt32(msg?.chatId),
                ChatMessage = msg?.msgText,
                SentTime = (DateTime)msg?.sentTime,
                SentByUserId = msg?.sentByUserId
            };
            _dataService.CreateChatLog(chatMessage);
            _hubContext.Clients.Group(msg?.chatId).SendAsync("ReceiveOne", msg.sentByUserId, msg.msgText);
            return Ok();
        }

    }
}
