using AnkaYazilim.OnMuhasebe.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AnkaYazilim.OnMuhasebe;

[DependsOn(
    typeof(OnMuhasebeEntityFrameworkCoreTestModule)
    )]
public class OnMuhasebeDomainTestModule : AbpModule
{

}
