namespace AnkaYazilim.OnMuhasebe.Exceptions;

public class DuplicateCodeException:BusinessException
{
    public DuplicateCodeException(string kod): base(OnMuhasebeDomainErrorCodes.DuplicateKod)
    {
        WithData("kod", kod);
    }

    public DuplicateCodeException(string code = null, string message = null, string details = null, Exception innerException = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Warning) : base(code, message, details, innerException, logLevel)
    {
    }
}
