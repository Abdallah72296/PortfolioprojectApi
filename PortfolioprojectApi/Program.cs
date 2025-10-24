using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.core;
using PortfolioProject.Data.Helpers;
using PortfolioProject.Infrastructure.Context;
using PortfolioProject.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

#region Dependency injections

builder.Services.Configure<EmailSettings>(options => { configuration.GetSection("emailSettings").Bind(options); });
builder.Services.Configure<JwtSettings>(options => { configuration.GetSection("Jwt").Bind(options); });

builder.Services.AddApplicationServices();
builder.Services.AddCoreServices(configuration);
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
