using AnkaYazilim.OnMuhasebe.DTOs.FaturaHareketler;

namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class FaturaHareketService : BaseHareketService<SelectFaturaHareketDto>, IScopedDependency
{
    public FaturaService FaturaService { get; set; }//property injection

    public override void GetTotal()
    {
        base.GetTotal();
    }
}