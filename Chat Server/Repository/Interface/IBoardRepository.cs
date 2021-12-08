using ChatRepository;

namespace Chat_Server.Repository.Interface
{
    public interface IBoardRepository
    {
        public Task<Board> GetBoard(long id);
        public Task CreateBoard(int rootid, string title);
        public Task CreateCard(int boardid, string title, string description,string state, DateTime deadline);
    }
}
