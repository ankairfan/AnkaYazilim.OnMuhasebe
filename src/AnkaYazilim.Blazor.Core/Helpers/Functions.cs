using AnkaYazilim.Blazor.Core.Models;
using Microsoft.Extensions.Localization;

namespace AnkaYazilim.Blazor.Core.Helpers;

public static class Functions
{
    public static List<ComboBoxEnumItem<TEnum>> FillEnumToComboBox<TEnum>(IStringLocalizer localizer) where TEnum : Enum
    {
        return Enum.GetValues(typeof(TEnum))
            .OfType<TEnum>()
            .Select(t => new ComboBoxEnumItem<TEnum>()
            {
                Value = t,
                DisplayName = localizer[$"Enum:{typeof(TEnum).Name}:{t.To<byte>()}"]
            }).ToList();
    }
}
