using ChatRepository;

namespace Chat_Server.Repository.Interface
{
    public interface IBoardRepository
    {
        public Task<Board> GetBoard(long id);
        public Task<long> CreateBoard(long rootid, string title);
        public Task UpdateBoard(long id, string title);
        public Task<Card> GetCard(ulong id);
        public Task<ulong> CreateCard(long boardid, string title, string description,string state, DateTime deadline);
        public Task<Card> UpdateCard(ulong cardid, string? title, string? description, string? state, DateTime? deadline);
        public Task DeleteCard(ulong cardid);
        public Task<ulong> CloneCard(ulong cardid, long newboardid);

    }
}
