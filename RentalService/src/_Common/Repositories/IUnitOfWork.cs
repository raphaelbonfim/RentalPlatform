namespace Common.Repositories;

public interface IUnitOfWork
{
    object Session { get; }
    void BeginTransaction();
    Task CommitAsync();
    Task RollbackAsync();
    void CloseTransaction();
    Task ExecuteUnderTransaction(Action action);
}