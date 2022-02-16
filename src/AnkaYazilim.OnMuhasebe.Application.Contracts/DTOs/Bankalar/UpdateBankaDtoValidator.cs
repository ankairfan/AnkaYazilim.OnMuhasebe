﻿namespace AnkaYazilim.OnMuhasebe.DTOs.Bankalar;

public class UpdateBankaDtoValidator : AbstractValidator<UpdateBankaDto>
{
    public UpdateBankaDtoValidator(IStringLocalizer<OnMuhasebeResource> localizer)
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

        RuleFor(x => x.Aciklama)
           .MaximumLength(EntityConsts.MaxAciklamaLength)
           .WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLenght, localizer["Description"], EntityConsts.MaxAciklamaLength]);
    }
}
