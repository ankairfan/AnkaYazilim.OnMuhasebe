using Volo.Abp.Modularity;

namespace AnkaYazilim.OnMuhasebe;

[DependsOn(
    typeof(OnMuhasebeApplicationModule),
    typeof(OnMuhasebeDomainTestModule)
    )]
public class OnMuhasebeApplicationTestModule : AbpModule
{

}
