namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class StokService : BaseService<ListStokDto, SelectStokDto>, IScopedDependency
{
    public override void SelectEntity(IEntityDto targetEntity)
    {
        if (targetEntity is SelectFaturaHareketDto hareket)
        {
            hareket.StokId = SelectedItem.Id;
            hareket.StokKodu = SelectedItem.Kod;
            hareket.StokAdi = SelectedItem.Ad;
            hareket.BirimAdi = SelectedItem.BirimAdi;
            hareket.AlisFiyat = SelectedItem.AlisFiyat;
            hareket.SatisFiyat = SelectedItem.SatisFiyat;
            hareket.KdvOran = SelectedItem.KdvOran;
        }
    }
}