using api;
using api.Entities;
using api.Middleware;
using api.Services;
using api.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var authenticationSettings = new AuthenticationSettings();
builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
    };
});
builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddControllers();
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AngularConnectionString")));
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountValidation, AccountValdation>();
builder.Services.AddScoped<ExceptionMiddleware>();
builder.Services.AddCors();

var app = builder.Build();

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "DatingApp");
});

app.UseCors(builder => builder.AllowAnyHeader()
.AllowAnyMethod()
.WithOrigins("https://localhost:4200"));

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
