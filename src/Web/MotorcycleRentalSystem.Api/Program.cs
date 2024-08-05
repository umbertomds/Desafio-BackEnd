using Microsoft.OpenApi.Models;
using MotorcycleRentalSystem.Api.Middlewares;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Domain.Options;
using MotorcycleRentalSystem.Infrastructure.Services;
using MotorcycleRentalSystem.Application.UseCases.RentQuotes.Read;
using MotorcycleRentalSystem.Application.UseCases.RentOrders.Read;
using MotorcycleRentalSystem.Application.UseCases.RentOrders.Create;
using MotorcycleRentalSystem.Application.UseCases.RentOrders.Update;
using MotorcycleRentalSystem.Application.UseCases.Motorcycles.Delete;
using MotorcycleRentalSystem.Application.UseCases.Motorcycles.Read;
using MotorcycleRentalSystem.Application.UseCases.Motorcycles.Create;
using MotorcycleRentalSystem.Application.UseCases.Motorcycles.Update;
using MotorcycleRentalSystem.Application.UseCases.Deliverymen.Create;
using MotorcycleRentalSystem.Application.UseCases.Deliverymen.Update;
using MotorcycleRentalSystem.Application.UseCases.Authorization.Execute;
using MotorcycleRentalSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using MotorcycleRentalSystem.Domain.Contracts;
using MotorcycleRentalSystem.Infrastructure.Repositories;
using MotorcycleRentalSystem.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Infrastructure.Updater;
using Microsoft.Extensions.Options;

WebApplicationOptions aa;
aa = new();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRentQuoteService, RentQuoteService>();

// Add repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
builder.Services.AddScoped<IRentOrderRepository, RentOrderRepository>();

// Add usecases
builder.Services.AddScoped<IReadRentQuotesUseCase, ReadRentQuotesUseCase>();
builder.Services.AddScoped<IReadRentOrdersUseCase, ReadRentOrdersUseCase>();
builder.Services.AddScoped<ICreateRentOrdersUseCase, CreateRentOrdersUseCase>();
builder.Services.AddScoped<IUpdateRentOrdersUseCase, UpdateRentOrdersUseCase>();
builder.Services.AddScoped<IReadMotorcyclesUseCase, ReadMotorcyclesUseCase>();
builder.Services.AddScoped<ICreateMotorcyclesUseCase, CreateMotorcyclesUseCase>();
builder.Services.AddScoped<IUpdateMotorcyclesUseCase, UpdateMotorcyclesUseCase>();
builder.Services.AddScoped<IDeleteMotorcyclesUseCase, DeleteMotorcyclesUseCase>();
builder.Services.AddScoped<ICreateDeliverymenUseCase, CreateDeliverymenUseCase>();
builder.Services.AddScoped<IUpdateDeliverymenUseCase, UpdateDeliverymenUseCase>();
builder.Services.AddScoped<IExecuteAuthorizationUseCase, ExecuteAuthorizationUseCase>();

// Add configuration objects
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));

// Add password hasher provider
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// Add Postgres EF provider
builder.Services.AddDbContext<AppDbContext>(db =>  db.UseNpgsql(builder.Configuration.GetConnectionString("PostgresCNS")), ServiceLifetime.Singleton);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Motorcycle Rental API",
        Description = ".NET 8 Web API"
    });
    // To Enable authorization using Swagger (JWT)
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n" + 
                      "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
                      "Example: \"Bearer 12345abcdef\"",
    });
    swagger.AddSecurityRequirement(new() {
    {
        new()
        {
            Reference = new ()
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }
    });
});


var app = builder.Build();

// post settings after building the app
var updater = new AppDbContextUpdater();
var scope = app.Services;
var dbContext = scope.GetService<AppDbContext>();
var config = scope.GetService<IOptions<AppSettings>>();
var cnts = scope.GetService<IOptions<ConnectionStrings>>();

updater.UpdateDatabase(dbContext!, null);

app.UseMiddleware<JwtMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || (config?.Value.UseSwagger ?? false))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
