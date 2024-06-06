using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
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
        /* LOGICA BOUNDED

        builder.Entity<FavoriteSource>().ToTable("FavoriteSource");
        builder.Entity<FavoriteSource>().HasKey(f => f.Id);
        builder.Entity<FavoriteSource>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<FavoriteSource>().Property(f => f.NewsApiKey).IsRequired();
        builder.Entity<FavoriteSource>().Property(f => f.SourceId).IsRequired();
        
        */
        builder.UseSnakeCaseNamingConvention();
        
    }
    
}