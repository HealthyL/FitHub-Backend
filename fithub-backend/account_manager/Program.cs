using BackEnd_FitHub.security.Authorization.Handlers.Implementations;
using BackEnd_FitHub.security.Authorization.Handlers.Interfaces;
using BackEnd_FitHub.security.Authorization.Middleware;
using BackEnd_FitHub.security.Authorization.Settings;
using BackEnd_FitHub.TechXPrime.Domain.Repositories;
using BackEnd_FitHub.TechXPrime.Domain.Services;
using BackEnd_FitHub.TechXPrime.Mapping;
using BackEnd_FitHub.TechXPrime.Services;
using BackEnd_FitHub.Shared.Persistence.Contexts;
using BackEnd_FitHub.Shared.Persistence.Repositories;
using BackEnd_FitHub.TechXPrime.Persistence.Repositories;
using BackEnd_FitHub.security.Domain.Repositories;
using BackEnd_FitHub.security.Domain.Services.Communication;
using BackEnd_FitHub.security.Persistence.Repository;
using BackEnd_FitHub.security.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add CORS
builder.Services.AddCors();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at 
https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
// Add API Documentation Information
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "TechXPrime API",
        Description = "TechXPrime RESTful API",
        TermsOfService = new Uri("https://techxprime.com/tos"),
        Contact = new OpenApiContact
        {
            Name = "TechXPrime.studio",
            Url = new Uri("https://techxprime.studio")
        },
        License = new OpenApiLicense
        {
            Name = "TechXPrime Resources License",
            Url = new Uri("https://techxprime.com/license")
        }
    });
    options.EnableAnnotations();
    options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type =
                    ReferenceType.SecurityScheme, Id = "bearerAuth" }
            },
            Array.Empty<string>()
        }
    });
});


// Add Database Connection
var connectionString = 
    builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Shared Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AppSettings Configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Dependency Injection Configuration
builder.Services.AddScoped<IAnalyticRepository, AnalyticsRepository>();
builder.Services.AddScoped<IAnalyticService, AnalyticService>();
builder.Services.AddScoped<IOrderRepository, OrdersRepository>();
builder.Services.AddScoped<IOrderService, OrdersService>();
builder.Services.AddScoped<IRequestRepository, RequestsRepository>();
builder.Services.AddScoped<IRequestService, RequestsService>();
builder.Services.AddScoped<ITechnicalRepository, TechnicalsRepository>();
builder.Services.AddScoped<ITechnicalService, TechnicalsService>();
builder.Services.AddScoped<IClientRepository, ClientsRepository>();
builder.Services.AddScoped<IClientService, ClientsService>();

// Security Injection Configuration
builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile), 
    typeof(ResourceToModelProfile),
    typeof(BackEnd_FitHub.security.Mapping.ModelToResourceProfile),
    typeof(BackEnd_FitHub.security.Mapping.ResourceToModelProfile));



var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("v1/swagger.json", "v1");
    options.RoutePrefix = "swagger";
});

if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// Configure CORS 
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure Error Handler Middleware
app.UseMiddleware<ErrorHandlerMiddleware>();
// Configure JWT Handling
app.UseMiddleware<JwtMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();