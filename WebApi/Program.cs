using Core.Configuration;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Services;
using SharedLibrary.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
builder.Services.AddScoped(typeof(IGenericService<,>), (typeof(GenericService<,>)));

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("SqlServer"), sqlOptions =>
    {
        sqlOptions.MigrationsAssembly("Data");
    });
});


builder.Services.AddIdentity<UserApp, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


builder.Services.Configure<CustomTokenOption>(configuration.GetSection("TokenOptions"));
builder.Services.Configure<List<Client>>(configuration.GetSection("Clients"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
