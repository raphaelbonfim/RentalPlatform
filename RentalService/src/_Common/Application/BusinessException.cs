namespace Common.Application
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
        public BusinessException(string message, Exception e) : base(message, e) { }
    }
}
