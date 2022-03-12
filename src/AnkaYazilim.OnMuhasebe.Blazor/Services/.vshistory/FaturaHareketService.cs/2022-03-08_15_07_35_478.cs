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
            DataSource.HareketTuruAdi = L[$"Enum:FaturaHareketTuru:" +
                $"{ (byte)DataSource.HareketTuru }"];
            InsertOrUpdate();
            HasChanged();
        }
        else
            MessageService.Error(result.Errors.CreateValidationErrorMessage(L));
    }

    public void FaturaHareketTuruSelectedItemChanged(ComboBoxEnumItem<FaturaHareketTuru> selectedItem, Action hasChanged)
    {
        TempDataSource.HareketTuru = selectedItem.Value;
        hasChanged();

        TempDataSource.StokId = null;
        TempDataSource.StokAdi = null;
        TempDataSource.StokKodu = null;
        TempDataSource.MasrafId = null;
        TempDataSource.MasrafAdi = null;
        TempDataSource.MasrafKodu = null;
        TempDataSource.HizmetId = null;
        TempDataSource.HizmetAdi = null;
        TempDataSource.HizmetKodu = null;
        TempDataSource.AlisFiyat = 0;
        TempDataSource.KdvOran = 0;

        if (TempDataSource.HareketTuru == FaturaHareketTuru.Stok)
        {
            TempDataSource.DepoId = AppService.FirmaParametre.DepoId;
            TempDataSource.DepoAdi = AppService.FirmaParametre.DepoAdi;
        }
        else
        {
            TempDataSource.DepoId = null;
            TempDataSource.DepoAdi = null;
        }
    }

    public override void Hesapla(object value, string propertyName)
    {
        TempDataSource.GetType().GetProperty(propertyName).SetValue(TempDataSource, value);

        TempDataSource.BrutTutar = TempDataSource.Miktar * TempDataSource.AlisFiyat;

        TempDataSource.IndirimTutar = TempDataSource.IndirimTutar > TempDataSource.BrutTutar ? TempDataSource.BrutTutar : TempDataSource.IndirimTutar;

        TempDataSource.NetTutar = (TempDataSource.Miktar * TempDataSource.AlisFiyat) - TempDataSource.IndirimTutar;

        TempDataSource.KdvTutar = TempDataSource.NetTutar * TempDataSource.KdvOran / 100;

        TempDataSource.GenelTutar = TempDataSource.NetTutar + TempDataSource.KdvTutar;
    }
}