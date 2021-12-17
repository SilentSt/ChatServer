using Chat_Server.Repository;
using ChatRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<MessageRepository>();
builder.Services.AddSingleton<BoardRepository>();
builder.Services.AddScoped<ChatContext>();
//builder.Host.ConfigureWebHost(c => c.UseUrls("https://176.212.39.172:25565"));

var app = builder.Build();
app.Urls.Add("https://localhost:14875");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
