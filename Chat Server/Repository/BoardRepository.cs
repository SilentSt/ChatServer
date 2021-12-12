using Chat_Server.Repository.Interface;
using Chat_Server.Service;
using ChatRepository;
using Microsoft.EntityFrameworkCore;

namespace Chat_Server.Repository
{
    public class BoardRepository : IBoardRepository
    {
        ChatContext chatContext = new ();
        public async Task<Board> GetBoard(long id)
        {
            var board = await chatContext.Boards.FirstOrDefaultAsync(x => x.Id == id);
            if (board == null)
            {
                board = new Board() { Id = 0 };
            }
            return board;
        }

        public async Task<long> CreateBoard(long rootid, string title)
        {
            var id = Generator.Generate64Id();
            Board board = null;
            if (rootid < 0)
            {
                board = new Board() { Id = id, CompanyId = rootid, Title = title };
            }
            else
            {
                board = new Board() { Id = id, UserId = (int)rootid, Title = title };
            }
            await chatContext.Boards.AddAsync(board);
            await chatContext.SaveChangesAsync();
            return id;
        }

        public async Task<ulong> CreateCard(long boardid, string title, string description, string state, DateTime deadline)
        {
            var id = Generator.GenerateU64Id();
            var card = new Card()
                { Id = id ,BoardId = boardid, Title = title, Description = description, State = state, Deadline = deadline };
            await chatContext.Cards.AddAsync(card);
            await chatContext.SaveChangesAsync();
            return id;
        }

        public async Task<Card> UpdateCard(ulong cardid, string? title, string? description, string? state, DateTime? deadline)
        {
            var card = await GetCard(cardid);
            if (card.Id == 0) throw new Exception("404");
            card.Title = title ?? card.Title;
            card.Description = description ?? card.Description;
            card.State = state ?? card.State;
            card.Deadline = deadline ?? card.Deadline;
            chatContext.Cards.Update(card);
            await chatContext.SaveChangesAsync();
            return card;
        }

        public async Task DeleteCard(ulong cardid)
        {
            var card = await GetCard(cardid);
            if (card.Id == 0) throw new Exception("404");
            chatContext.Cards.Remove(card);
            await chatContext.SaveChangesAsync();
        }

        public async Task<ulong> CloneCard(ulong cardid, long newboardid)
        {
            var card = await GetCard(cardid);
            card.Id = Generator.GenerateU64Id();
            card.BoardId = newboardid;
            await chatContext.Cards.AddAsync(card);
            await chatContext.SaveChangesAsync();
            return card.Id;
        }

        public async Task<Card> GetCard(ulong id)
        {
            var card = await chatContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if (card == null)
            {
                card = new Card() { Id = 0 };
            }
            return card;
        }

        public async Task UpdateBoard(long id, string title)
        {
            var board = await GetBoard(id);
            if (board.Id == 0) throw new Exception("404");
            board.Title = title;
            chatContext.Boards.Update(board);
            await chatContext.SaveChangesAsync();
        }
    }
}
