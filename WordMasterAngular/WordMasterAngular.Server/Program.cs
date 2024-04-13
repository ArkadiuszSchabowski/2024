using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WordMaster.Server;
using WordMaster.Server.Middleware;
using WordMaster.Server.Seeders;
using WordMaster.Server.Services;
using WordMaster.ServerDatabase;
using WordMaster.ServerDatabase.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WordMasterAngularConnectionString")));

builder.Services.AddScoped<IFlashCardService, FlashCardService>();
builder.Services.AddScoped<IFlashCardSeeder, FlashCardSeeder>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddAutoMapper(typeof(FlashCardMappingProfile).Assembly);
builder.Services.AddCors();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x.WithOrigins("https://localhost:4200").AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.MapFallbackToFile("/index.html");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seeder = services.GetRequiredService<IFlashCardSeeder>();
    seeder.AddStartupFlashCards();
}

app.Run();
