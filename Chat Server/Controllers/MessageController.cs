using Chat_Server.BModels;

using Microsoft.AspNetCore.Mvc;

namespace Chat_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        
        public MessageController()
        {

        }

        [HttpPost("history")]
        public IEnumerable<string> GetHistory([FromBody] int userid)
        {

            return null;
        }
    }
}