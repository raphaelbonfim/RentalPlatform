namespace Common.Application;

public interface IApplicationCommandServiceAsync<T> where T : IApplicationCommand
{
    Task ProcessAsync(
        T command,
        CancellationToken cancellationToken = default);
}