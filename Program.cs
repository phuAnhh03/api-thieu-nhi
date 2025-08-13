using System.Text;
using api.Data;
using api.Interfaces;
using api.Models;
using api.Repositories;
using api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Database Context DI dotenv (migrate to secret handler soon)
// var db_host = Environment.GetEnvironmentVariable("DB_HOST");
// var db_username = Environment.GetEnvironmentVariable("DB_USERNAME");
// var db_password = Environment.GetEnvironmentVariable("DB_PASSWORD");
// var connectionString = $"Server={db_host},1433;Database=api_thieu_nhi;User Id={db_username};Password={db_password};TrustServerCertificate=True;";

var connectionString = $"Server=localhost,1433;Database=api_thieu_nhi;User Id=sa;Password=ducphubui623@gmail.com;TrustServerCertificate=True;";

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddIdentity<Account, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 4;
})
.AddEntityFrameworkStores<ApplicationDBContext>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidIssuer = builder.Configuration["JWT:Issuer"],
    ValidateAudience = true,
    ValidAudience = builder.Configuration["JWT:Audience"],
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
        )
    };
});
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{ options.UseSqlServer(connectionString); });
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<ICommentService, CommentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
