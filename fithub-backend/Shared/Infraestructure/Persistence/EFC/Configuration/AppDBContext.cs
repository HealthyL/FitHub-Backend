using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using fithub_backend.RutinesManagement.Domain.Model.Aggregates;
using fithub_backend.RutinesManagement.Domain.Model.Entities;
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
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
    
}