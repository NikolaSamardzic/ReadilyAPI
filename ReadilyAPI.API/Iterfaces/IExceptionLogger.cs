namespace ReadilyAPI.API.Iterfaces
{
    public interface IExceptionLogger
    {
        Guid Log(Exception exception);
    }
}
