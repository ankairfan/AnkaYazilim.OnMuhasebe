namespace AnkaYazilim.OnMuhasebe.Blazor.Helpers;

public static class ExtensionFunctions
{
    public static string CreateValidationErrorMessage(this IList<ValidationFailure> errors, IStringLocalizer localizer)
    {
        var builder = new StringBuilder();
        builder.Append(localizer);
    }
}