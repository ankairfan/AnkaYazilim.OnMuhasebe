namespace AnkaYazilim.OnMuhasebe.DTOs.Faturalar;

public class SelectFaturaHareketDtoValidator : AbstractValidator<SelectFaturaHareketDto>
{
    public SelectFaturaHareketDtoValidator(IStringLocalizer localizer)
    {
        RuleFor(x => x.StokId)
           .Must(x => x.HasValue && x.Value != Guid.Empty)
           .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Customer"]]);
    }
}