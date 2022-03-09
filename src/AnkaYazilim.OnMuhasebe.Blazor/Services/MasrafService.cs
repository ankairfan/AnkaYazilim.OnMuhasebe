namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class MasrafService : BaseService<ListMasrafDto, SelectMasrafDto>, IScopedDependency
{
    public override void SelectEntity(IEntityDto targetEntity)
    {
        if (targetEntity is SelectFaturaHareketDto hareket)
        {
            hareket.MasrafId = SelectedItem.Id;
            hareket.MasrafKodu = SelectedItem.Kod;
            hareket.MasrafAdi = SelectedItem.Ad;
            hareket.BirimAdi = SelectedItem.BirimAdi;
            hareket.AlisFiyat = SelectedItem.AlisFiyat;
            hareket.SatisFiyat = SelectedItem.SatisFiyat;
            hareket.KdvOran = SelectedItem.KdvOran;
        }
    }
}
