using AnkaYazilim.OnMuhasebe.DTOs.FaturaHareketler;

namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class FaturaHareketService : BaseHareketService<SelectFaturaHareketDto>, IScopedDependency
{
    public FaturaService FaturaService { get; set; }//property injection
    public AppService AppService { get; set; }//property injection

    public override void BeforeInsert()
    {
        DataSource = new SelectFaturaHareketDto
        {
            DepoId = AppService.FirmaParametre.DepoId,
            DepoAdi = AppService.FirmaParametre.DepoAdi,
            HareketTuru = Faturalar.FaturaHareketTuru.Stok
        };

        EditPageVisible = true;
    }

    public override void GetTotal()
    {
        FaturaService.DataSource.BrutTutar = ListDataSource.Sum(x => x.BrutTutar);
        FaturaService.DataSource.IndirimTutari = ListDataSource.Sum(x => x.IndirimTutar);
        FaturaService.DataSource.NetTutar = ListDataSource.Sum(x => x.NetTutar);
        FaturaService.DataSource.KdvTutar = ListDataSource.Sum(x => x.KdvTutar);
        FaturaService.DataSource.GenelTutar = ListDataSource.Sum(x => x.GenelTutar);
        FaturaService.DataSource.HareketSayisi = ListDataSource.Count;
    }

    public override void OnSubmit()
    {
        var validator = new SelectFaturaHareketDtoValidator(L);
        var result = validator.Validate(TempDataSource);

        if (result.IsValid)
        {
            DataSource = TempDataSource;
            DataSource.HareketTuruAdi = L[$"Enum:FaturaHareketTuru:{(byte)DataSource.HareketTuru}"];
            InsertOrUpdate();
            HasChanged();
        }
        else
            MessageService.Error(result.Errors.cr)
    }
}