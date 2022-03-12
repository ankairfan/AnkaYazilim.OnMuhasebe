namespace AnkaYazilim.OnMuhasebe.DTOs.MakbuzHareketler;

public class SelectMakbuzHareketDtoValidator : AbstractValidator<SelectMakbuzHareketDto>
{
    public SelectMakbuzHareketDtoValidator(IStringLocalizer localizer)
    {
        RuleFor(x => x.CekBankaId)
    .NotEmpty()
    .When(x => x.OdemeTuru == OdemeTuru.Cek)
    .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Bank"]]);

        RuleFor(x => x.CekBankaSubeId)
.NotEmpty()
.When(x => x.OdemeTuru == OdemeTuru.Cek)
.WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["BankBranch"]]);

        RuleFor(x => x.CekHesapNo)
    .NotEmpty()
    .When(x => x.OdemeTuru == OdemeTuru.Cek)
    .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["CheckAccountNumber"]])

    .MaximumLength(MakbuzHareketConsts.MaxCekHesapNoLength)
    .WithMessage(
        localizer[
            OnMuhasebeDomainErrorCodes.MaxLenght,
            localizer["CheckAccountNumber"],
            MakbuzHareketConsts.MaxCekHesapNoLength]);

        RuleFor(x => x.CekHesapNo)
    .Empty()
    .When(x => x.OdemeTuru != OdemeTuru.Cek)
    .WithMessage(localizer[OnMuhasebeDomainErrorCodes.IsNull, localizer["CheckAccountNumber"]]);

        RuleFor(x => x.BelgeNo)
        .NotEmpty()
        .When(x => x.OdemeTuru == OdemeTuru.Cek)
        .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["DocumentNumber"]])

        .MaximumLength(MakbuzHareketConsts.MaxBelgeNoLength)
        .WithMessage(
            localizer[
                OnMuhasebeDomainErrorCodes.MaxLenght,
                localizer["DocumentNumber"],
                MakbuzHareketConsts.MaxBelgeNoLength]);

        RuleFor(x => x.AsilBorclu)
    .NotEmpty()
    .When(x => x.OdemeTuru == OdemeTuru.Cek || x.OdemeTuru == OdemeTuru.Senet)
    .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["PrincipalDebtor"]])

    .MaximumLength(MakbuzHareketConsts.MaxAsilBorcluLength)
    .WithMessage(
        localizer[
            OnMuhasebeDomainErrorCodes.MaxLenght,
            localizer["PrincipalDebtor"],
            MakbuzHareketConsts.MaxAsilBorcluLength]);

        RuleFor(x => x.AsilBorclu)
    .Empty()
    .When(x => x.OdemeTuru != OdemeTuru.Cek && x.OdemeTuru != OdemeTuru.Senet)
    .WithMessage(localizer[OnMuhasebeDomainErrorCodes.IsNull, localizer["PrincipalDebtor"]]);

        RuleFor(x => x.Ciranta)
            .MaximumLength(MakbuzHareketConsts.MaxCirantaLength)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.MaxLenght,
                    localizer["Endorser"],
                    MakbuzHareketConsts.MaxCirantaLength]);

        RuleFor(x => x.Ciranta)
            .Empty()
            .When(x => x.OdemeTuru != OdemeTuru.Cek && x.OdemeTuru != OdemeTuru.Senet)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.IsNull, localizer["Endorser"]]);

        RuleFor(x => x.KasaId)
          .NotEmpty()
          .When(x => x.OdemeTuru == OdemeTuru.Nakit)
          .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Safe"]]);

        RuleFor(x => x.BankaHesapId)
        .NotEmpty()
        .When(x => x.OdemeTuru == OdemeTuru.Banka || x.OdemeTuru == OdemeTuru.Pos)
        .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["BankAccount"]]);

        RuleFor(x => x.Tutar)
    .GreaterThanOrEqualTo(0)
    .WithMessage(
        localizer[
            OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
            localizer["Total"],
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