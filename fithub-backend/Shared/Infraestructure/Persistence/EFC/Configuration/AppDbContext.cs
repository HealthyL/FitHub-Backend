using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //LOGICA BOUNDED
        builder.Entity<AlimentationProduct>().ToTable("AlimentationProduct");
        builder.Entity<CardioProduct>().ToTable("CardioProduct");
        
        builder.Entity<AlimentationProduct>().HasKey(f => f.Id);
        builder.Entity<AlimentationProduct>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<AlimentationProduct>().Property(f => f.Name).IsRequired();
        builder.Entity<AlimentationProduct>().Property(f=>f.Description).IsRequired();
        builder.Entity<AlimentationProduct>().Property(f=>f.Price).IsRequired();
        builder.Entity<AlimentationProduct>().Property(f=>f.PhotoUrl).IsRequired();
        builder.Entity<AlimentationProduct>().Property(f=>f.Category).IsRequired();
        
        builder.Entity<CardioProduct>().HasKey(f => f.Id);
        builder.Entity<CardioProduct>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<CardioProduct>().Property(f => f.Name).IsRequired();
        builder.Entity<CardioProduct>().Property(f=>f.Description).IsRequired();
        builder.Entity<CardioProduct>().Property(f=>f.Price).IsRequired();
        builder.Entity<CardioProduct>().Property(f=>f.PhotoUrl).IsRequired();
        builder.Entity<CardioProduct>().Property(f => f.Category).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();
        
    }
    
}