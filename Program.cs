using api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);
DotEnv.Load();

// Database Context DI
var db_host = Environment.GetEnvironmentVariable("DB_HOST");
var db_username = Environment.GetEnvironmentVariable("DB_USERNAME");
var db_password = Environment.GetEnvironmentVariable("DB_PASSWORD");
var connectionString = $"Server={db_host},1433;Database=api_thieu_nhi;User Id={db_username};Password={db_password},TrustServerCertificate=True;";

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{ options.UseSqlServer(builder.Configuration.GetConnectionString(connectionString)); });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();
// installed dotnet -ef