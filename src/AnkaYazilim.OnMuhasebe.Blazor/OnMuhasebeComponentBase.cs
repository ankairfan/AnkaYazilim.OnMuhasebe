using AnkaYazilim.OnMuhasebe.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AnkaYazilim.OnMuhasebe.Blazor;

public abstract class OnMuhasebeComponentBase : AbpComponentBase
{
    protected OnMuhasebeComponentBase()
    {
        LocalizationResource = typeof(OnMuhasebeResource);
    }
}
