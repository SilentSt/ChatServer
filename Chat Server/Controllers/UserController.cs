using System.Text.Json.Nodes;
using Chat_Server.BModels;
using Chat_Server.Repository;
using Chat_Server.Repository.Interface;
using Chat_Server.Service;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json.Linq;

namespace Chat_Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository userdata;

        public UserController(UserRepository data)
        {
            userdata = data;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Auth auth)
        {
            var user = await userdata.Login(auth.login, auth.password);
            if (user.Id>0){
                var token = Generator.GenerateToken();
                await userdata.AddToken(user, token);
                var log = new Login() { nickname = user.NickName,token=token };
                return new ContentResult(){Content= JObject.FromObject(log).ToString(), StatusCode=200};
            }
            return BadRequest();
        }

        [HttpPost("company")]
        public async Task<IActionResult> Company([FromBody] string token)
        {
            var user = await userdata.GetUser(token);
            var users = await userdata.GetCompanyUsers(user.CompanyId);
            List<ComUser> usersList = new List<ComUser>();
            foreach (var us in users)
            {
                usersList.Add(new ComUser(){id=us.Id,nick = us.NickName});
            }

            return new ContentResult() { Content = JArray.FromObject(usersList).ToString(), StatusCode = 200 };
        }
    }
}
