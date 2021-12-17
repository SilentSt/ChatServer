using Chat_Server.BModels;
using Chat_Server.BModels.Message;
using Chat_Server.Repository;
using Chat_Server.Repository.Interface;

using ChatRepository;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json.Linq;

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
        public async Task<IActionResult> Message([FromBody] CreateMessage message)
        {
            try
            {
                if ((await userdata.GetUser(message.token)).Id == 0) return NotFound();
                var user = userdata.GetUser(message.token);
                var messageId = await messagedata.SendMessage(user.Id, message.toid, message.text, message.reply);
                return new ContentResult(){Content = messageId.ToString(),StatusCode = 200};
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpPost("privatechat")]
        public async Task<IActionResult> CreatePrivateChat([FromBody] CreatePrivateChat chat)
        {

            try
            {
                var user = await userdata.GetUser(chat.token);
                if (user.Id == 0) return NotFound();
                var id = await messagedata.CreatePrivateChat(user.Id, chat.friend);
                return new ContentResult { Content = id.ToString(), StatusCode = 200 };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpPost("chat")]
        public async Task<IActionResult> CreateChat([FromBody] CreateChat chat)
        {

            try
            {
                var user = await userdata.GetUser(chat.token);
                if (user.Id == 0) return NotFound();
                var id = await messagedata.CreateChat(user.Id,chat.name);
                return new ContentResult { Content = id.ToString(), StatusCode = 200 };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.Message);
                return BadRequest();
            }

        }

        [HttpPost("addusertochat")]
        public async Task<IActionResult> AddUserToChat([FromBody] AddUserToChat chat)
        {
            try
            {
                if ((await userdata.GetUser(chat.token)).Id == 0) return NotFound();
                await messagedata.AddUserToChat(chat.userid, chat.chatid);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpPost("userchats")]
        public async Task<IActionResult> Chats([FromBody] string token)
        {
            try
            {
                var user = await userdata.GetUser(token);
                if (user.Id == 0) return NotFound();
                var chats = messagedata.GetChats(user.Id);
                return new ContentResult { Content = JArray.FromObject(chats).ToString(), StatusCode = 200 };

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpPost("history")]
        public async Task<IActionResult> GetHistory([FromBody] GetHistory data)
        {
            try
            {
                if ((await userdata.GetUser(data.token)).Id == 0) return NotFound();
                var user = userdata.GetUser(data.token);
                List<Message> messages;
                if (data.skip != null && data.take != null)
                {
                    messages = await messagedata.GetPrivateMessages(user.Id, data.id, (int)data.skip, (int)data.take);
                }
                else
                if (data.skip != null)
                {
                    messages = await messagedata.GetPrivateMessages(user.Id, data.id, (int)data.skip);
                }
                else
                if (data.take != null)
                {
                    messages = await messagedata.GetPrivateMessages(user.Id, data.id, take: (int)data.take);
                }
                else
                {
                    messages = await messagedata.GetPrivateMessages(user.Id, data.id);
                }

                return new ContentResult { Content = JArray.FromObject(messages).ToString(), StatusCode = 200 };

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }
    }
}