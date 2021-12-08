using Chat_Server.BModels;
using Chat_Server.Repository;
using Chat_Server.Repository.Interface;
using ChatRepository;
using Microsoft.AspNetCore.Mvc;

namespace Chat_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        IMessageRepository messagedata;
        IUserRepository userdata;
        public MessageController(UserRepository udata, MessageRepository mdata)
        {
            userdata = udata;
            messagedata = mdata;
        }

        [HttpPost("message")]
        public async Task<IActionResult> Message([FromBody] InMessage message)
        {
            var user = userdata.GetUser(message.token);
            await messagedata.SendMessage(user.Id, message.toid, message.text, message.reply);
            return Ok();
        }
        [HttpPost("history")]
        public async Task<IEnumerable<Message>> GetHistory([FromBody] GetHistory data)
        {
            var user = userdata.GetUser(data.token);
            if (data.skip != null && data.take != null)
            {
                return await messagedata.GetMessages(user.Id, data.id, (int)data.skip, (int)data.take);
            }
            if (data.skip != null)
            {
                return await messagedata.GetMessages(user.Id, data.id,(int)data.skip);
            } 
            if (data.take != null)
            {
                return await messagedata.GetMessages(user.Id, data.id, take:(int)data.take);
            }
            return await messagedata.GetMessages(user.Id, data.id);
        }
    }
}