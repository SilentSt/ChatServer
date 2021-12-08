using Chat_Server.Repository.Interface;
using ChatRepository;

namespace Chat_Server.Repository
{
    public class MessageRepository : IMessageRepository
    {
        ChatContext chatContext = new ();

        public async Task<List<Message>> GetMessages(int userid, int friendid, int skip = 0, int take = 25)
        {
            var messages = chatContext.History.Where(x => x.FromId == userid || x.ToId == userid)
                .Where(y => y.FromId == friendid || y.ToId == friendid).Skip(skip).Take(take);
            return messages.ToList();
        }

        public async Task SendMessage(int fromid, int toid, string text, string? reply = null)
        {
            await chatContext.History.AddAsync(new Message()
                { FromId = fromid, ToId = toid, UtcTime = DateTime.UtcNow, Reply = reply });
            await chatContext.SaveChangesAsync();
        }
    }
}
