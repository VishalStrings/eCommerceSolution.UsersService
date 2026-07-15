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

//Add API explorer services
builder.Services.AddEndpointsApiExplorer();

//Add swagger generateion services to create swagger specs
builder.Services.AddSwaggerGen();

//Add cors related service
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseExceptionHandlingMiddleware();
//Routing
app.UseRouting();

//adds endpoint that can serve the swagger.json
app.UseSwagger();
app.UseSwaggerUI(); // adds swagger UI 

app.UseCors("AllowAngular");  //Add CORS

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routrs
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
