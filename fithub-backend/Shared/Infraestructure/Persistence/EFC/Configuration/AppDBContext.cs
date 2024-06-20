using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Entities;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;

public class AppDBContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Nutrition>().ToTable("Nutrition");
        builder.Entity<Nutrition>().HasKey(f => f.Id);
        builder.Entity<Nutrition>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Nutrition>().Property(f => f.Name).IsRequired();
        builder.Entity<Nutrition>().Property(f=>f.Description).IsRequired();
        builder.Entity<Nutrition>().Property(f=>f.PhotoUrl).IsRequired();
        builder.Entity<Nutrition>().Property(f=>f.ClassificationId).IsRequired();
        
        builder.Entity<Classification>().HasKey(f=>f.Id);
        builder.Entity<Classification>().Property(f=>f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Classification>().Property(f=>f.Name).IsRequired();
        
        builder.Entity<Classification>()
            .HasMany(c => c.Nutritions)
            .WithOne(t => t.Classification)
            .HasForeignKey(t => t.ClassificationId)
            .HasPrincipalKey(t => t.Id);
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
    
}