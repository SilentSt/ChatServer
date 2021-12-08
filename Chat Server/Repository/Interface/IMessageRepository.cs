using ChatRepository;

namespace Chat_Server.Repository.Interface
{
    public interface IMessageRepository
    {
        public Task SendMessage(int fromid, int toid, string text, string? reply = null);
        public Task<List<Message>> GetMessages(int userid, int friendid, int skip=0,int take=25);

    }
}
