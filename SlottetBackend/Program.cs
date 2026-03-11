using Scalar.AspNetCore;
using SlottetBackend.Infrastructure;
using SlottetBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Dependency Injection(?)
builder.Services.AddScoped<IResidentSchemaRepo, ResidentSchemaMemoryRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //Scalar (+ nuget Scalar.ASP.net core)
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Slottet Backend");
        options.WithTheme(ScalarTheme.Mars);
        options.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
