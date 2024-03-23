public class InvariantViolationException : Exception
{
    public InvariantViolationException(string message): base(message) {}
    public InvariantViolationException(string message, Exception e): base(message, e) {}
}