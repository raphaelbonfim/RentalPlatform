namespace Common.Application;

public interface IApplicationQueryServiceAsync<TQ, TR> 
    where TQ : IApplicationQuery where TR: IApplicationQueryResult
{
    Task<TR> ProcessAsync(
        TQ query,
        CancellationToken cancellationToken = default);
}