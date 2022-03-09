using AnkaYazilim.OnMuhasebe.DTOs.FaturaHareketler;

namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class FaturaHareketService : BaseHareketService<SelectFaturaHareketDto>, IScopedDependency
{
    public FaturaService FaturaService { get; set; }//property injection

    public override void GetTotal()
    {
        FaturaService.DataSource.BrutTutar = ListDataSource.Sum(x => x.BrutTutar);
        FaturaService.DataSource.IndirimTutari = ListDataSource.Sum(x => x.IndirimTutar);
        FaturaService.DataSource.NetTutar = ListDataSource.Sum(x => x.NetTutar);
        FaturaService.DataSource.KdvTutar = ListDataSource.Sum(x => x.KdvTutar);
        FaturaService.DataSource.GenelTutar = ListDataSource.Sum(x => x.GenelTutar);
        FaturaService.DataSource.HareketSayisi = ListDataSource.Count;
    }
}