using ChatRepository;

namespace Chat_Server.Repository.Interface
{
    public interface IUserRepository
    {
        public Task<User> GetUser(int id);
        public Task<User> GetUser(string token);
        public Task<List<User>> GetCompanyUsers(long id);
        public Task<Company> GetFullCompany(long id);
        public Task<List<User>> FindUsers(string nickname);
        public Task<User> FindUser(string nickname);
        public Task<User> Login(string username, string password);
        public Task AddToken(User user, string token);
        public Task AddToken(int userid, string token);
    }
}
