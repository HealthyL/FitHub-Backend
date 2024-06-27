using fithub_backend.Shared.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;
using fithub_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDBContext Context;

    protected BaseRepository(AppDBContext context) => Context = context;
    
    // Register / Add / POST
    public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);
    
    //Update 
    public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);
    
    //Delete
    public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);
    
    //Select / Get
    
    //Get one or zero record
    public async Task<TEntity?> FindByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id);
    
    //Get many records
    public async Task<IEnumerable<TEntity>> ListAsync() => await Context.Set<TEntity>().ToListAsync();
}