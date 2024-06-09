using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    /**
     * This method is used to configure the context to CONNECT to the database
     */
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }
    
    /**
     * This method is used to configure the model that will be used to CREATE the database
     */
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        /*LOGICA DEL NUTRITION BOUNDED*/
        builder.Entity<BreakfastItem>().ToTable("BreakfastItem");
        builder.Entity<BreakfastItem>().HasKey(f=>f.Id);
        builder.Entity<BreakfastItem>().Property(f=>f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<BreakfastItem>().Property(f=>f.Tittle).IsRequired();
        builder.Entity<BreakfastItem>().Property(f => f.Ingredients).IsRequired();
        builder.Entity<BreakfastItem>().Property(f=>f.PhotoUrl).IsRequired();
        builder.Entity<BreakfastItem>().Property(f=>f.Category).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();
    }
}