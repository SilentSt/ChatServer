using Chat_Server.BModels.Boards;
using Chat_Server.Repository;
using Chat_Server.Repository.Interface;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chat_Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private IBoardRepository boarddata;
        IUserRepository userdata;
        public BoardController(BoardRepository bdata, UserRepository udata)
        {
            boarddata = bdata;
            userdata = udata;
        }

        [HttpPost("board")]
        public async Task<IActionResult> CreateBoard([FromBody] InBoard board)
        {
            try
            {
                var user = await userdata.GetUser(board.token);
                long boardid;
                if (board.priv)
                {
                    boardid = await boarddata.CreateBoard(user.Id, board.title);
                }
                else
                {
                    boardid = await boarddata.CreateBoard(user.CompanyId, board.title);
                }

                if (boardid == 0) return NotFound();
                return new ContentResult() { Content = boardid.ToString(), StatusCode = 200 };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpPost("updateboard")]
        public async Task<IActionResult> UpdateBoard([FromBody] UpBoard board)
        {
            try
            {
                if ((await userdata.GetUser(board.token)).Id == 0) return NotFound();
                await boarddata.UpdateBoard(board.boardid, board.title);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpPost("card")]
        public async Task<IActionResult> CreateCard([FromBody] InCard card)
        {
            try
            {
                if ((await userdata.GetUser(card.token)).Id == 0) return NotFound();
                var id = await boarddata.CreateCard(card.boardid, card.title, card.description, card.state,
                    card.deadline);
                if (id == 0) return BadRequest();
                return new ContentResult(){Content = id.ToString(),StatusCode = 200};
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpPost("updatecard")]
        public async Task<IActionResult> UpdateCard([FromBody]UpCard card)
        {
            try
            {
                if ((await userdata.GetUser(card.token)).Id == 0) return NotFound();
                await boarddata.UpdateCard(card.cardid, card.title, card.description, card.state, card.deadline);
                return Ok();
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
