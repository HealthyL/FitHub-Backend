using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using fithub_backend.IAM.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Entities;
using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Entities;
using fithub_backend.Profiles.Domain.Model.Aggregates;
using fithub_backend.RutinesManagement.Domain.Model.Aggregates;
using fithub_backend.RutinesManagement.Domain.Model.Entities;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;
namespace fithub_backend.Shared.Infrastructure.Persistence.EFC.Configuration;

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
        
        builder.Entity<Product>().ToTable("Product");
        builder.Entity<Product>().HasKey(f => f.Id);
        builder.Entity<Product>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(f => f.Name).IsRequired();
        builder.Entity<Product>().Property(f=>f.Description).IsRequired();
        builder.Entity<Product>().Property(f=>f.Price).IsRequired();
        builder.Entity<Product>().Property(f=>f.PhotoUrl).IsRequired();
        builder.Entity<Product>().Property(f=>f.CategoryId).IsRequired();
        
        builder.Entity<Category>().HasKey(f=>f.Id);
        builder.Entity<Category>().Property(f=>f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(f=>f.Name).IsRequired();
        
        builder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(t => t.Category)
            .HasForeignKey(t => t.CategoryId)
            .HasPrincipalKey(t => t.Id);
        
        //bounded context Rutine
        builder.Entity<Exercise>().ToTable("Exercise");
        builder.Entity<Exercise>().HasKey(f => f.Id);
        builder.Entity<Exercise>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Exercise>().Property(f => f.Name).IsRequired();
        builder.Entity<Exercise>().Property(f => f.PhotoUrl).IsRequired();
        builder.Entity<Exercise>().Property(f => f.Sets).IsRequired();
        builder.Entity<Exercise>().Property(f => f.Reps).IsRequired();
        builder.Entity<Exercise>().Property(f => f.Weight).IsRequired();
        builder.Entity<Exercise>().Property(f => f.RoutineId).IsRequired();
        
        builder.Entity<Routine>().HasKey(f => f.Id);
        builder.Entity<Routine>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Routine>().Property(f => f.Name).IsRequired();
        
        builder.Entity<Routine>()
            .HasMany(c => c.Exercises)
            .WithOne(t => t.Routine)
            .HasForeignKey(t => t.RoutineId)
            .HasPrincipalKey(t => t.Id);
        
        //Nutrition
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
        
        //Profile
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FullName).HasColumnName("FullName");
            });

        builder.Entity<Profile>().OwnsOne(p => p.Email,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Address).HasColumnName("EmailAddress");
            });
        builder.Entity<Profile>().OwnsOne(p => p.Birthdate,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Date).HasColumnName("Birthdate");
            });
        //User
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
    
}