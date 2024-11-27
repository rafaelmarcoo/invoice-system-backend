using invoice_system_backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Retrieve password from environment variable
var password = Environment.GetEnvironmentVariable("PG_PASSWORD");

// Add DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                            .Replace("ENV_DB_PASSWORD", password);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));
Console.WriteLine($"Connection String: {connectionString}");

// Add services to the container.
builder.Services.AddControllers();

// Enabling CORS for React App
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
