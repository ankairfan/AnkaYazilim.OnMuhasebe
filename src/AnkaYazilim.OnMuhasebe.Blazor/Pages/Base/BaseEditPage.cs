namespace AnkaYazilim.OnMuhasebe.Blazor.Pages.Base;

public abstract class BaseEditPage : AbpComponentBase
{
    public BaseEditPage()
    {
        LocalizationResource = typeof(OnMuhasebeResource);
    }

    [Parameter, EditorRequired] public EventCallback OnSubmit { get; set; }
}
