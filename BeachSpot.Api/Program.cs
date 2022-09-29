using BeachSpot.Api.Authorization;
using BeachSpot.Application;
using BeachSpot.Persistence;
using BeachSpot.QuotesRestProvider;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddQuotesRestServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

//This will run EF migrations on Startup
await using var scope = app.Services.CreateAsyncScope();
using var db = scope.ServiceProvider.GetService<BeachSpotDBContext>();
await db.Database.MigrateAsync();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

// custom basic auth middleware
app.UseMiddleware<BasicAuthMiddleware>();

app.MapControllers();

app.Run();

//For intagration tests purpose
public partial class Program { }