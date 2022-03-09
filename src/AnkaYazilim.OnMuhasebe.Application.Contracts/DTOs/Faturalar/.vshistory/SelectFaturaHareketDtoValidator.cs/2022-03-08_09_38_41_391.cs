namespace AnkaYazilim.OnMuhasebe.DTOs.Faturalar;

public class SelectFaturaHareketDtoValidator : AbstractValidator<SelectFaturaHareketDto>
{
    public SelectFaturaHareketDtoValidator(IStringLocalizer localizer)
    {
        RuleFor(x => x.StokId)
           .NotEmpty()
           .When(x => x.HareketTuru == FaturaHareketTuru.Stok)
           .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Stock"]]);

        RuleFor(x => x.HizmetId)
   .NotEmpty()
   .When(x => x.HareketTuru == FaturaHareketTuru.Hizmet)
   .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Service"]]);

        RuleFor(x => x.MasrafId)
   .NotEmpty()
   .When(x => x.HareketTuru == FaturaHareketTuru.Masraf)
   .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Expense"]]);

        RuleFor(x => x.DepoId)
   .NotEmpty()
   .When(x => x.HareketTuru == FaturaHareketTuru.Stok)
   .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Warehouse"]]);


    }
}