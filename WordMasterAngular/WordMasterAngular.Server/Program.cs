using Microsoft.EntityFrameworkCore;
using WordMaster.Server;
using WordMaster.Server.Seeders;
using WordMaster.Server.Services;
using WordMaster.ServerDatabase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WordMasterAngularConnectionString")));

builder.Services.AddScoped<IFlashCardService, FlashCardService>();
builder.Services.AddScoped<IFlashCardSeeder, FlashCardSeeder>();

builder.Services.AddAutoMapper(typeof(FlashCardMappingProfile).Assembly);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seeder = services.GetRequiredService<IFlashCardSeeder>();
    seeder.AddStartupFlashCards();
}

app.Run();
