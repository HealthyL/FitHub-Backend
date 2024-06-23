using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using fithub_backend.Profiles.Domain.Model.Aggregates;
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
        builder.Entity<Profile>().OwnsOne(p => p.Objective,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Type).HasColumnName("Objective");
            });
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
    
}