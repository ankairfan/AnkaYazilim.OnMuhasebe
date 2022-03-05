namespace AnkaYazilim.OnMuhasebe.Blazor.Pages.Base;

public abstract class BaseEditPage : AbpComponentBase
{
    public BaseEditPage()
    {
        LocalizationResource = typeof(OnMuhasebeResource);
    }

    [Parameter] public EventCallback OnSubmit { get; set; }
}