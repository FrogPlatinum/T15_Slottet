using Slottet.API;
using Slottet.Infrastructure;
using Scalar.AspNetCore;
using Slottet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Slottet.Application.Interfaces;
using Slottet.Application.Services;
using Slottet.Domain.Entity;
using Slottet.Application.Settings;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//DB Context (NuGet Package EF Core SqlServer)
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<UserDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("UserDbConnection")));

//DI
builder.Services.AddScoped<IGenericRepo<ResidentSchema>, ResidentSchemaDBrepo>();
builder.Services.AddScoped<IGenericRepo<User>, UserDbRepo>();
builder.Services.AddScoped<IResidentSchemaService, ResidentSchemaService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();

//JWT
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("Jwt"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Slottet Backend");
        options.WithTheme(ScalarTheme.DeepSpace);
        options.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
