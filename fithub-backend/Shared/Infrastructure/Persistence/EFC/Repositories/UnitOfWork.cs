using fithub_backend.Shared.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;
using fithub_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore.Storage;

namespace fithub_backend.Shared.Infrastructure.Persistence.EFC.Repositories;


public class UnitOfWork(AppDBContext context) : IUnitOfWork
{
    private readonly AppDBContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly Stack<IDbContextTransaction> _transactions = new();

    public async Task BeginTransactionAsync()
    {
        var transaction = await _context.Database.BeginTransactionAsync();
        _transactions.Push(transaction);
    }

    public async Task CommitTransactionAsync()
    {
        if (_transactions.Count == 0)
            throw new InvalidOperationException("There is no transaction in progress to commit.");

        var transaction = _transactions.Pop();
        if (_transactions.Count == 0)
        {
            try
            {
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                await transaction.DisposeAsync();
            }
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transactions.Count == 0)
            throw new InvalidOperationException("There is no transaction in progress to rollback.");

        var transaction = _transactions.Pop();
        try
        {
            await transaction.RollbackAsync();
        }
        finally
        {
            await transaction.DisposeAsync();
        }
    }

    public async Task CompleteAsync()
    {
        if (_transactions.Count == 0)
        {
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new InvalidOperationException("There are transactions in progress. Use CommitTransactionAsync or RollbackTransactionAsync.");
        }
    }
}
