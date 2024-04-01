namespace Common.Messaging
{
    public interface IMessagingSender
    {
        Task PublishAsync(string queueName, IIntegrationMessage message);
        Task PublishAllAsync(string queueName, ICollection<IIntegrationMessage> messages);
    }
}
