namespace Common.Application;

public interface IApplicationCommandServiceWithResultAsync<TC, TR> 
    where TC : IApplicationCommand where TR: IApplicationCommandResult
{
    Task<TR> ProcessAsync(
        TC command,
        CancellationToken cancellationToken = default);
}