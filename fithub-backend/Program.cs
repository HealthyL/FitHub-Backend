////"server=40.78.100.52; user=FitHub; password=12345678; database=fithubdb"

using fithub_backend.IAM.Application.Internal.CommandServices;
using fithub_backend.IAM.Application.Internal.OutboundServices;
using fithub_backend.IAM.Application.Internal.QueryServices;
using fithub_backend.IAM.Domain.Repositories;
using fithub_backend.IAM.Domain.Services;
using fithub_backend.IAM.Infrastructure.Hashing.BCrypt.Services;
using fithub_backend.IAM.Infrastructure.Persistence.EFC.Repositories;
using fithub_backend.IAM.Infrastructure.Tokens.JWT.Configuration;
using fithub_backend.IAM.Infrastructure.Tokens.JWT.Services;
using fithub_backend.IAM.Interfaces.ACL;
using fithub_backend.IAM.Interfaces.ACL.Services;
using fithub_backend.NutritionManagement.Application.Internal.CommandServices;
using fithub_backend.NutritionManagement.Application.Internal.QueryServices;
using fithub_backend.NutritionManagement.Domain.Repositories;
using fithub_backend.NutritionManagement.Domain.Services;
using fithub_backend.NutritionManagement.Infraestructure.Persistence.EFC.Repositories;
using fithub_backend.ProductsManagement.Application.Internal.CommandService;
using fithub_backend.ProductsManagement.Application.Internal.QueryService;
using fithub_backend.ProductsManagement.Domain.Services;
using fithub_backend.ProductsManagement.Infraestructure.Persistence.EFC.Repositories;
using fithub_backend.ProductsManagement.Infraestructure.Repositories;
using fithub_backend.Profiles.Application.Internal.CommandService;
using fithub_backend.Profiles.Application.Internal.QueryService;
using fithub_backend.Profiles.Domain.Repositories;
using fithub_backend.Profiles.Domain.Services;
using fithub_backend.Profiles.Infraestructure.Persistence.EFC.Repositories;
using fithub_backend.RutinesManagement.Application.Internal.CommandService;
using fithub_backend.RutinesManagement.Application.Internal.QueryService;
using fithub_backend.RutinesManagement.Domain.Repositories;
using fithub_backend.RutinesManagement.Domain.Services;
using fithub_backend.RutinesManagement.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using fithub_backend.Shared.Domain.Repositories;
using fithub_backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using fithub_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using fithub_backend.Shared.Interfaces.ASP.Configuration;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDBContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    }
);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title="FitHub",
                Version="v1",
                Description="FitHub API",
                TermsOfService=new Uri("https://fithub.com/tos"),
                Contact=new OpenApiContact
                {
                    Name="FitHub Studios",
                    Email="fithub@klock.com"
                },
                License=new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            }
        });
        
    }
);

builder.Services.AddRouting(options=>options.LowercaseUrls = true);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Bounded Context Products
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryCommandService, CategoryCommandService>();
builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();

//bounded context Rutine
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseCommandService, ExerciseCommandService>();
builder.Services.AddScoped<IExerciseQueryService, ExerciseQueryService>();
builder.Services.AddScoped<IRoutineRepository, RoutineRepository>();
builder.Services.AddScoped<IRoutineCommandService, RoutineCommandService>();
builder.Services.AddScoped<IRoutineQueryService, RoutineQueryService>();

//bounded context Nutrition
builder.Services.AddScoped<INutritionRepository, NutritionRepository>();
builder.Services.AddScoped<INutritionCommandService, NutritionCommandService>();
builder.Services.AddScoped<INutritionQueryService, NutritionQueryService>();

builder.Services.AddScoped<IClassificationRepository, ClassificationRepository>();
builder.Services.AddScoped<IClassificationCommandService, ClassificationCommandService>();
builder.Services.AddScoped<IClassificationQueryService, ClassificationQueryService>();

// Profiles Bounded Context Profiles
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();
//objectives
builder.Services.AddScoped<IObjectiveRepository, ObjectiveRepository>();
builder.Services.AddScoped<IObjectiveCommandService, ObjectiveCommandService>();
builder.Services.AddScoped<IObjectiveQueryService, ObjectiveQueryService>();

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context= services.GetRequiredService<AppDBContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllPolicy");

// Add Authorization Middleware to Pipeline
//app.UseRequestAuthorization();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
