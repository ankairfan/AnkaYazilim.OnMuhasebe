﻿namespace AnkaYazilim.OnMuhasebe.DTOs.Hizmetler;

public class CreateHizmetDtoValidator : AbstractValidator<CreateHizmetDto>
{
    public CreateHizmetDtoValidator(IStringLocalizer<OnMuhasebeResource> localizer)
    {
        RuleFor(x => x.Kod)
            .NotEmpty()
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Code"]])

            .MaximumLength(EntityConsts.MaxKodLength)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLenght, localizer["Code"], EntityConsts.MaxKodLength]);

        RuleFor(x => x.Ad)
            .NotEmpty()
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Name"]])

            .MaximumLength(EntityConsts.MaxAdLength)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLenght, localizer["Name"], EntityConsts.MaxAdLength]);

        RuleFor(x => x.KdvOrani)
            .GreaterThanOrEqualTo(0)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                    localizer["TaxRate"],
                    localizer["ToZero"],
                    localizer["ThanZero"]]);

        RuleFor(x => x.BirimFiyat)
          .GreaterThanOrEqualTo(0)
          .WithMessage(
              localizer[
                  OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                  localizer["UnitPrice"],
                  localizer["ToZero"],
                  localizer["ThanZero"]]);

        RuleFor(x => x.Barkod)
         .MaximumLength(EntityConsts.MaxBarkodLength)
         .WithMessage(
             localizer[
                 OnMuhasebeDomainErrorCodes.MaxLenght,
                 localizer["Barcode"],
                 EntityConsts.MaxBarkodLength]);

        RuleFor(x => x.BirimId)
            .Must(x => x.HasValue && x.Value != Guid.Empty)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Unit"]]);

        RuleFor(x => x.Aciklama)
            .MaximumLength(EntityConsts.MaxAciklamaLength)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.MaxLenght,
                    localizer["Description"],
                    EntityConsts.MaxAciklamaLength]);
    }
}
