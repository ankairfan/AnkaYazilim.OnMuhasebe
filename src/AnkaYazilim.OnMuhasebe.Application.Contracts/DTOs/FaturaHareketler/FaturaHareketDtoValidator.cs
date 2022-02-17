namespace AnkaYazilim.OnMuhasebe.DTOs.FaturaHareketler;

public class FaturaHareketDtoValidator : AbstractValidator<FaturaHareketDto>
{
    public FaturaHareketDtoValidator(IStringLocalizer localizer)
    {
        RuleFor(x => x.Id)
            .Must(x => x.HasValue && x.Value != Guid.Empty)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Id"]]);

        RuleFor(x => x.HareketTuru)
            .IsInEnum()
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["RowType"]])

            .NotEmpty()
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["RowType"]]);

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

        RuleFor(x => x.Miktar)
            .GreaterThanOrEqualTo(0)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                    localizer["Quantity"],
                    localizer["ToZero"],
                    localizer["ThanZero"]]);

        RuleFor(x => x.Fiyat)
            .GreaterThanOrEqualTo(0)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                    localizer["Price"],
                    localizer["ToZero"],
                    localizer["ThanZero"]]);

        RuleFor(x => x.IndirimOran)
            .GreaterThanOrEqualTo(0)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                    localizer["DiscountRate"],
                    localizer["ToZero"],
                    localizer["ThanZero"]]);

        RuleFor(x => x.KdvOran)
            .GreaterThanOrEqualTo(0)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                    localizer["TaxRate"],
                    localizer["ToZero"],
                    localizer["ThanZero"]]);

        RuleFor(x => x.BrutTutar)
            .GreaterThanOrEqualTo(0)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                    localizer["GrossTotal"],
                    localizer["ToZero"],
                    localizer["ThanZero"]]);

        RuleFor(x => x.IndirimTutar)
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

        RuleFor(x => x.Aciklama)
            .MaximumLength(EntityConsts.MaxAciklamaLength)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.MaxLenght,
                    localizer["Description"],
                    EntityConsts.MaxAciklamaLength]);
    }
}
