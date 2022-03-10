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

    public static string[] RowHeights(params string[] rowHeights)
    {
        return rowHeights;
    }

    public static string[] ColumnWidths(params string[] colWidths)
    {
        return colWidths;
    }

    public static string CreateId()//19 haneli kod üretiliyor.
    {
        string AddZero(string value, bool threeDigits = false)
        {
            if (threeDigits)
                return value.Length switch
                {
                    1 => "00" + value,
                    2 => "0" + value,
                    _ => value,
                };

            return value.Length switch
            {
                1 => "0" + value,
                _ => value,
            };
        }

        string Id()//2022010112122000335
        {
            var year = DateTime.Now.Date.Year.ToString();//2022
            var month = AddZero(DateTime.Now.Date.Month.ToString());//01
            var day = AddZero(DateTime.Now.Date.Day.ToString());//01
            var hour = AddZero(DateTime.Now.Hour.ToString());//12
            var minute = AddZero(DateTime.Now.Minute.ToString());//12
            var second = AddZero(DateTime.Now.Second.ToString());//20
            var millisecond = AddZero(DateTime.Now.Millisecond.ToString(), true);//003
            var random = AddZero(new Random().Next(0, 99).ToString());//35

            return year + month + day + hour + minute + second + millisecond + random;
        }

        return Id();
    }
}
