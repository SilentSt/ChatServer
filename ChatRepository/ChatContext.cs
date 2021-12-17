using Microsoft.EntityFrameworkCore;

namespace ChatRepository
{
    public class ChatContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=drag;user=sDether;password=1namQfeg1_;");
            //optionsBuilder.UseMySQL("server=217.25.89.68;database=drag;user=sDether;password=1namQfeg1_;");
            base.OnConfiguring(optionsBuilder);
        }

        public async Task Reload()
        {
            await Entry(nameof(Chat)).ReloadAsync();
            await Entry(nameof(Message)).ReloadAsync();
            await Entry(nameof(Company)).ReloadAsync();
            await Entry(nameof(Board)).ReloadAsync();
            await Entry(nameof(Card)).ReloadAsync();
            await Entry(nameof(User)).ReloadAsync();
            await Entry(nameof(Tokens)).ReloadAsync();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> History { get; set; }
        public DbSet<Tokens> Tokens { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Card> Cards { get; set; }

    }
}