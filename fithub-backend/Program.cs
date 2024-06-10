using fithub_backend.NutritionManagement.Application.Internal.CommandServices;
using fithub_backend.NutritionManagement.Application.Internal.QueryServices;
using fithub_backend.NutritionManagement.Domain.Repositories;
using fithub_backend.NutritionManagement.Domain.Services;
using fithub_backend.NutritionManagement.Infraestructure.Repositories;
using fithub_backend.Shared.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Interfaces.ASP.Configuration;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(
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
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();    
    });
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddRouting(options=>options.LowercaseUrls=true);

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IBreakfastItemRepository, BreakfastItemsRepository>();
builder.Services.AddScoped<IBreakfastItemCommandService, BreakfastItemCommandService>();
builder.Services.AddScoped<IBreakfastItemQueryService, BreakfastItemQueryService>();

builder.Services.AddScoped<IDinnerItemRepository, DinnerItemsRepository>();
builder.Services.AddScoped<IDinnerItemCommandService, DinnerItemCommandService>();
builder.Services.AddScoped<IDinnerItemQueryService, DinnerItemQueryService>();

builder.Services.AddScoped<ILunchItemRepository, LunchItemsRepository>();
builder.Services.AddScoped<ILunchItemCommandService, LunchItemCommandService>();
builder.Services.AddScoped<ILunchItemQueryService, LunchItemQueryService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context= services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();