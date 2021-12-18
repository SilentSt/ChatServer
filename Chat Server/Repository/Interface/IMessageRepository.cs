using Chat_Server.BModels.Boards;
using ChatRepository;

namespace Chat_Server.Repository.Interface
{
    public interface IMessageRepository
    {
        public Task<int> SendMessage(int fromid, long toid, string text, string? reply = null);
        public Task<long> CreatePrivateChat(int userid, int friendid);
        public Task<long> CreateChat(int userid, string name);
        public Task<List<Message>> GetMessages(int userid, long chatid, int skip=0,int take=25);
        public Task<List<UserChats>> GetChats(int userid);
        public Task AddUserToChat(int userid, long chatid);
    }
}
