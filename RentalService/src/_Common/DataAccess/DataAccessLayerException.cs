namespace Common.DataAccess;

public class DataAccessLayerException: Exception
{
    public DataAccessLayerException(string message): base(message) {}
    public DataAccessLayerException(string message, Exception e): base(message, e) {}
}