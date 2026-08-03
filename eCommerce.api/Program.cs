using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.api.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using FluentValidation.AspNetCore;


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
//automapper class added all the mappingprofile classes automatically
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

//Fluent Validation
builder.Services.AddFluentValidationAutoValidation();


var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseSwagger();
app.UseSwaggerUI(); // adds swagger UI 

app.UseCors("AllowAngular");  //Add CORS

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routrs
app.MapControllers();

app.MapGet("/", () => "Hello World Polly");

app.Run();
