using api.Data;
using api.Interfaces;
using api.Repositories;
using api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Database Context DI dotenv (migrate to secret handler soon)
// var db_host = Environment.GetEnvironmentVariable("DB_HOST");
// var db_username = Environment.GetEnvironmentVariable("DB_USERNAME");
// var db_password = Environment.GetEnvironmentVariable("DB_PASSWORD");
// var connectionString = $"Server={db_host},1433;Database=api_thieu_nhi;User Id={db_username};Password={db_password};TrustServerCertificate=True;";

var connectionString = $"Server=localhost,1433;Database=api_thieu_nhi;User Id=sa;Password=ducphubui623@gmail.com;TrustServerCertificate=True;";

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
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

app.MapControllers();

app.Run();
// installed dotnet -ef