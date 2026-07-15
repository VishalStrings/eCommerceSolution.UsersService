using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.api.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// add infr services

builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add Controllers
builder.Services.AddControllers().AddJsonOptions
    (options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
var app = builder.Build();

app.UseExceptionHandlingMiddleware();
//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routrs
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
