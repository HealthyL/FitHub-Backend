using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
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
        
       //Profile Context
       builder.Entity<ProfileManagement.Domain.Model.Aggregates.Profile>().HasKey(p => p.Id);
       builder.Entity<ProfileManagement.Domain.Model.Aggregates.Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
       builder.Entity<ProfileManagement.Domain.Model.Aggregates.Profile>().OwnsOne(p => p.Name,
           n =>
           {
               n.WithOwner().HasForeignKey("Id");
               n.Property(m => m.FirstName).HasColumnName("FirstName");
               n.Property(m => m.LastName).HasColumnName("LastName");
           });
       
       builder.Entity<ProfileManagement.Domain.Model.Aggregates.Profile>().OwnsOne(p => p.Email,
           e =>
           {
               e.WithOwner().HasForeignKey("Id");
               e.Property(m => m.Address).HasColumnName("Email");
           });
       
       builder.Entity<ProfileManagement.Domain.Model.Aggregates.Profile>().OwnsOne(p => p.Address,
           a =>
           {
               a.WithOwner().HasForeignKey("Id");
               a.Property(m => m.Street).HasColumnName("Street");
               a.Property(m => m.Number).HasColumnName("Number");
               a.Property(m => m.City).HasColumnName("City");
               a.Property(m => m.PostalCode).HasColumnName("PostalCode");
               a.Property(m => m.Country).HasColumnName("Country");
           });

        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
    
}