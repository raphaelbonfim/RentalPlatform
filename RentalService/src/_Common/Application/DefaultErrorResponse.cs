
namespace Common.Application
{
    public class DefaultErrorResponse
    {
        public DefaultErrorResponse(
            string errorType,
            string errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public string ErrorType { get; }
        public string ErrorMessage { get; }
    }
}
