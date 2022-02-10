namespace AnkaYazilim.OnMuhasebe.Exceptions;

public class CannotBeDeletedException:BusinessException
{
    public CannotBeDeletedException() : base(OnMuhasebeDomainErrorCodes.CannotBeDeleted)
    {

    }
}
