namespace AnkaYazilim.OnMuhasebe.DTOs.Makbuzlar;

public class CreateMakbuzDtoValidator : AbstractValidator<CreateMakbuzDto>
{
    public CreateMakbuzDtoValidator(IStringLocalizer<OnMuhasebeResource> localizer)
    {
        RuleFor(x => x.MakbuzTuru)
            .IsInEnum()
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["ReceiptType"]])

            .NotEmpty()
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["ReceiptType"]]);

        RuleFor(x => x.MakbuzNo)
            .NotEmpty()
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["ReceiptNumber"]])

            .MaximumLength(MakbuzConsts.MaxMakbuzNoLength)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.MaxLenght,
                    localizer["ReceiptNumber"],
                    MakbuzConsts.MaxMakbuzNoLength]);

        RuleFor(x => x.Tarih).NotEmpty().WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Date"]]);

        RuleFor(x => x.KasaId)
            .NotEmpty()
            .When(x => x.MakbuzTuru == MakbuzTuru.KasaIslem)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Safe"]]);

        RuleFor(x => x.KasaId)
            .Empty()
            .When(x => x.MakbuzTuru != MakbuzTuru.KasaIslem)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.IsNull, localizer["Safe"]]);

        RuleFor(x => x.CariId)
            .NotEmpty()
            .When(x => x.MakbuzTuru == MakbuzTuru.Tahsilat || x.MakbuzTuru == MakbuzTuru.Odeme)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Customer"]]);

        RuleFor(x => x.CariId)
            .Empty()
            .When(x => x.MakbuzTuru != MakbuzTuru.Tahsilat && x.MakbuzTuru != MakbuzTuru.Odeme)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.IsNull, localizer["Customer"]]);


        RuleFor(x => x.BankaHesapId)
            .NotEmpty()
            .When(x => x.MakbuzTuru == MakbuzTuru.BankaIslem)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["BankAccount"]]);

        RuleFor(x => x.BankaHesapId)
            .Empty()
            .When(x => x.MakbuzTuru != MakbuzTuru.BankaIslem)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.IsNull, localizer["BankAccount"]]);

        RuleFor(x => x.HareketSayisi)
            .GreaterThanOrEqualTo(0)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                    localizer["NumberOfMoves"],
                    localizer["ToZero"],
                    localizer["ThanZero"]]);


        RuleFor(x => x.CekToplamTutar)
            .GreaterThanOrEqualTo(0)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                    localizer["CheckTotal"],
                    localizer["ToZero"],
                    localizer["ThanZero"]]);

        RuleFor(x => x.SenetToplamTutar)
            .GreaterThanOrEqualTo(0)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                    localizer["DebentureTotal"],
                    localizer["ToZero"],
                    localizer["ThanZero"]]);

        RuleFor(x => x.PosToplamTutar)
            .GreaterThanOrEqualTo(0)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                    localizer["PosTotal"],
                    localizer["ToZero"],
                    localizer["ThanZero"]]);

        RuleFor(x => x.NakitToplamTutar)
            .GreaterThanOrEqualTo(0)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                    localizer["CashTotal"],
                    localizer["ToZero"],
                    localizer["ThanZero"]]);


        RuleFor(x => x.BankaToplamTutar)
            .GreaterThanOrEqualTo(0)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
                    localizer["BankTotal"],
                    localizer["ToZero"],
                    localizer["ThanZero"]]);


        RuleFor(x => x.SubeId)
            .Must(x => x.HasValue && x.Value != Guid.Empty)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Branch"]]);

        RuleFor(x => x.DonemId)
            .Must(x => x.HasValue && x.Value != Guid.Empty)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Period"]]);

        RuleFor(x => x.Aciklama)
            .MaximumLength(EntityConsts.MaxAciklamaLength)
            .WithMessage(
                localizer[
                    OnMuhasebeDomainErrorCodes.MaxLenght,
                    localizer["Description"],
                    EntityConsts.MaxAciklamaLength]);

        RuleForEach(x => x.MakbuzHareketler).SetValidator(y => new MakbuzHareketDtoValidator(localizer));
    }
}
