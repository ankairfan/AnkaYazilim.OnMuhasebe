namespace AnkaYazilim.OnMuhasebe.Exceptions;

public class CannotBeDeletedException:BusinessException
{
    public CannotBeDeletedException() : base(OnMuhasebeDomainErrorCodes.CannotBeDeleted)
    {

    }

    public CannotBeDeletedException(string code = null, string message = null, string details = null, Exception innerException = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Warning) : base(code, message, details, innerException, logLevel)
    {
    }
}
