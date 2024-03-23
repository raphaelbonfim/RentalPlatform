namespace Common.Application;

public class Notification
{
    public string Message { get; }
    public Exception Exception { get; }

    public Notification(string message)
    {
        Message = message;
    }

    public Notification(string message, Exception exception)
    {
        Message = message;
        Exception = exception;
    }
}