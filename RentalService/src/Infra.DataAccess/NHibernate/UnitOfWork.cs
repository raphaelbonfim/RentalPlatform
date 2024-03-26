using Common.Repositories;
using NHibernate;

public class UnitOfWork : IUnitOfWork
{
    private readonly ISession _session;
    private ITransaction _transaction;

    public object Session => _session;

    public UnitOfWork(ISession session) 
        => _session = session;
        
    public void BeginTransaction()
    {
        _transaction = _session.BeginTransaction();
    }

    public async Task CommitAsync()
    {
        await _transaction.CommitAsync();
    }

    public async Task RollbackAsync()
    {
        await _transaction.RollbackAsync();
    }

    public void CloseTransaction()
    {
        if (_transaction != null)
        {
            _transaction.Dispose();
            _transaction = null;
        }
    }

    public async Task ExecuteUnderTransaction(Action action)
    {
        using var transaction = _session.BeginTransaction();
        action();
                
        await transaction.CommitAsync();
    }
}