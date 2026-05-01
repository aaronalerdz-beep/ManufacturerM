using API.Middleware;
using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MContext>(otp => {
        otp.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICycleStatsServices, CycleStatsServices>();
builder.Services.AddScoped<IOrderStatsService, OrderStatsService>();
builder.Services.AddCors();
builder.Services.AddAuthentication();
builder.Services.AddIdentityApiEndpoints<AppUser>().AddEntityFrameworkStores<MContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("https://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddlewar>();
app.UseCors("AllowAngular");
app.MapControllers();
app.MapGroup("api").MapIdentityApi<AppUser>();

app.Run();

internal class ConfigStatsServices
{
}