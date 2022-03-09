﻿namespace AnkaYazilim.OnMuhasebe.DTOs.Faturalar;

public class SelectFaturaHareketDtoValidator : AbstractValidator<SelectFaturaHareketDto>
{
    public SelectFaturaHareketDtoValidator(IStringLocalizer localizer)
    {
        RuleFor(x => x.StokId)
           .NotEmpty()
           .When(x => x.HareketTuru == FaturaHareketTuru.Stok)
           .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["stock"]]);
    }
}