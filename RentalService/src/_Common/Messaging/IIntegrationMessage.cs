namespace Common.Messaging;

public interface IIntegrationMessage
{
    /// <summary>
    ///     Date and time message was created.
    /// </summary>
    DateTime OccurredOn { get; }

    /// <summary>
    ///     Message instance type name.
    /// </summary>
    string MessageType { get; }

    /// <summary>
    ///     Unique identifier for tracking.
    /// </summary>
    Guid CorrelationId { get; set; }
}