namespace AnkaYazilim.OnMuhasebe.DTOs.Faturalar;

public class UpdateFaturaDtoValidator : AbstractValidator<UpdateFaturaDto>
{
    public UpdateFaturaDtoValidator(IStringLocalizer<OnMuhasebeResource> localizer)
    {
        RuleFor(x => x.FaturaNo)
            .NotEmpty()
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["InvoiceNumber"]])

            .MaximumLength(FaturaConsts.MaxFaturaNoLength)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.MaxLenght,
                    localizer["InvoiceNumber"],
                    FaturaConsts.MaxFaturaNoLength]);

        RuleFor(x => x.Tarih).NotEmpty().WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Date"]]);

        RuleFor(x => x.BrutTutar)
            .GreaterThanOrEqualTo(0)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                    localizer["GrossTotal"],
                    localizer["ToZero"],
                    localizer["ThanZero"]]);

        RuleFor(x => x.IndirimTutari)
           .GreaterThanOrEqualTo(0)
           .WithMessage(
               localizer[
                   OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                   localizer["DiscountTotal"],
                   localizer["ToZero"],
                   localizer["ThanZero"]]);

        RuleFor(x => x.NetTutar)
          .GreaterThanOrEqualTo(0)
          .WithMessage(
              localizer[
                  OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                  localizer["NetTotal"],
                  localizer["ToZero"],
                  localizer["ThanZero"]]);

        RuleFor(x => x.KdvTutar)
         .GreaterThanOrEqualTo(0)
         .WithMessage(
             localizer[
                 OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                 localizer["TaxTotal"],
                 localizer["ToZero"],
                 localizer["ThanZero"]]);

        RuleFor(x => x.GenelTutar)
         .GreaterThanOrEqualTo(0)
         .WithMessage(
             localizer[
                 OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                 localizer["GrandTotal"],
                 localizer["ToZero"],
                 localizer["ThanZero"]]);

        RuleFor(x => x.HareketSayisi)
         .GreaterThanOrEqualTo(0)
         .WithMessage(
             localizer[
                 OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                 localizer["NumberOfMoves"],
                 localizer["ToZero"],
                 localizer["ThanZero"]]);

        RuleFor(x => x.CariId)
           .Must(x => x.HasValue && x.Value != Guid.Empty)
           .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Customer"]]);

        RuleFor(x => x.Aciklama)
          .MaximumLength(EntityConsts.MaxAciklamaLength)
          .WithMessage(
              localizer[
                  OnMuhasebeDomainErrorCodes.MaxLenght,
                  localizer["Description"],
                  EntityConsts.MaxAciklamaLength]);

        RuleForEach(x => x.FaturaHareketleri)
            .SetValidator(y => new FaturaHareketDtoValidator(localizer));
    }
}