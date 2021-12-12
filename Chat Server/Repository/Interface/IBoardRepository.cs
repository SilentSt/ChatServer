using ChatRepository;

namespace Chat_Server.Repository.Interface
{
    public interface IBoardRepository
    {
        public Task<Board> GetBoard(long id);
        public Task<long> CreateBoard(long rootid, string title);
        public Task UpdateBoard(long id, string title);
        public Task<Card> GetCard(long id);
        public Task<long> CreateCard(long boardid, string title, string description,string state, DateTime deadline);
        public Task<Card> UpdateCard(long cardid, string? title, string? description, string? state, DateTime? deadline);
        public Task DeleteCard(long cardid);
        public Task<long> CloneCard(long cardid, long newboardid);

    }
}
