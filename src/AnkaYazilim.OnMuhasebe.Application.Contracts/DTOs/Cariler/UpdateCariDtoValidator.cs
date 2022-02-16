namespace AnkaYazilim.OnMuhasebe.DTOs.Cariler;

public class UpdateCariDtoValidator : AbstractValidator<UpdateCariDto>
{
    public UpdateCariDtoValidator(IStringLocalizer<OnMuhasebeResource> localizer)
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

        RuleFor(x => x.VergiDairesi)
            .MaximumLength(CariConsts.MaxVergiDairesiLength)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.MaxLenght,
                    localizer["TaxAdministration"],
                    CariConsts.MaxVergiDairesiLength]);

        RuleFor(x => x.VergiNumarasi)
            .MaximumLength(CariConsts.MaxVergiNoLength)
            .WithMessage(
                localizer[OnMuhasebeDomainErrorCodes.MaxLenght, localizer["TaxNumber"], CariConsts.MaxVergiNoLength]);

        RuleFor(x => x.TcNumarasi)
            .MaximumLength(CariConsts.MaxTcNoLength)
            .WithMessage(
                localizer[OnMuhasebeDomainErrorCodes.MaxLenght, localizer["NationalNumber"], CariConsts.MaxTcNoLength]);

        RuleFor(x => x.Telefon)
            .MaximumLength(EntityConsts.MaxTelefonLength)
            .WithMessage(
                localizer[OnMuhasebeDomainErrorCodes.MaxLenght, localizer["PhoneNumber"], EntityConsts.MaxTelefonLength]);

        RuleFor(x => x.MobilTelefon)
            .MaximumLength(EntityConsts.MaxTelefonLength)
            .WithMessage(
                localizer[OnMuhasebeDomainErrorCodes.MaxLenght, localizer["PhoneNumber"], EntityConsts.MaxTelefonLength]);

        RuleFor(x => x.Adres)
          .MaximumLength(EntityConsts.MaxAdresLength)
          .WithMessage(
              localizer[OnMuhasebeDomainErrorCodes.MaxLenght, localizer["Address"], EntityConsts.MaxAdresLength]);

        RuleFor(x => x.Aciklama)
            .MaximumLength(EntityConsts.MaxAciklamaLength)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.MaxLenght,
                    localizer["Description"],
                    EntityConsts.MaxAciklamaLength]);
    }
}
