using API.Middleware;
using Core.Entities;
using Core.Interfeces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MContext>(otp => {
        otp.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddCors();
builder.Services.AddAuthentication();
builder.Services.AddIdentityApiEndpoints<AppUser>().AddEntityFrameworkStores<MContext>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddlewar>();

app.UseCors("AllowAngular");
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowCredentials()
.WithOrigins("https://localhost:4200","https://localhost:4200"));

app.MapControllers();
app.MapGroup("api").MapIdentityApi<AppUser>();

app.Run();
