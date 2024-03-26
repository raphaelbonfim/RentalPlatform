using Common.Domain;
using Common.Repositories;
using NHibernate;

namespace Infra.DataAccess.Repositories;

public abstract class RepositoryBase<TAggregate> where TAggregate : Aggregate
{
    // ReSharper disable once InconsistentNaming
    private const string INVARIANT_VIOLATION_MESSAGE =
        "The {name} aggregate state is invalid. Check the domain invariants on the application services before to change an aggregate.";

    private readonly ISession _session;
    protected ISession Session => _session;

    public RepositoryBase(IUnitOfWork unitOfWork)
    {
        if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));

        _session = (ISession) unitOfWork.Session;
    }

    public async Task<TAggregate> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _session.GetAsync<TAggregate>(id, cancellationToken);
    }

    public async Task SaveOrUpdateAsync(TAggregate aggregate,
        CancellationToken cancellationToken = default)
    {
        
        if (aggregate.Invalid) throw new InvariantViolationException(INVARIANT_VIOLATION_MESSAGE.Replace("{name}", aggregate.GetType().Name));

        var currentTransaction = _session.GetCurrentTransaction();
        if (currentTransaction is { IsActive: true })
        {
            await _session.SaveOrUpdateAsync(aggregate, cancellationToken);
        }
        else
        {
            using var transaction = _session.BeginTransaction();
            await _session.SaveOrUpdateAsync(aggregate, cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
    }

    public async Task SaveOrUpdateBatchAsync(IEnumerable<TAggregate> aggregates, int batchSize, CancellationToken cancellationToken = default)
    {
        using var transaction = _session.BeginTransaction();
        _session.SetBatchSize(batchSize);
        var processedAggregates = 0;
        foreach (var aggregate in aggregates)
        {
            if (aggregate.Invalid) throw new InvariantViolationException(INVARIANT_VIOLATION_MESSAGE.Replace("{name}", aggregate.GetType().Name));
            
            await SaveOrUpdateAsync(aggregate, cancellationToken);
            processedAggregates++;
            

            if (processedAggregates % batchSize == 0)
            {
                await _session.FlushAsync(cancellationToken);
                _session.Clear();
            }
        }
        
        await transaction.CommitAsync(cancellationToken);
    }

    public async Task RemoveAsync(TAggregate aggregate,
        CancellationToken cancellationToken = default)
    {
        var currentTransaction = _session.GetCurrentTransaction();
        if (currentTransaction is { IsActive: true })
        {
            await _session.DeleteAsync(aggregate, cancellationToken);
        }
        else
        {
            using var transaction = _session.BeginTransaction();
            await _session.DeleteAsync(aggregate, cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
    }
}