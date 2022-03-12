namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class HizmetService : BaseService<ListHizmetDto, SelectHizmetDto>, IScopedDependency
{
    public override void SelectEntity(IEntityDto targetEntity)
    {
        if (targetEntity is SelectFaturaHareketDto hareket)
        {
            hareket.HizmetId = SelectedItem.Id;
            hareket.HizmetKodu = SelectedItem.Kod;
            hareket.HizmetAdi = SelectedItem.Ad;
            hareket.BirimAdi = SelectedItem.BirimAdi;
            hareket.AlisFiyat = SelectedItem.AlisFiyat;
            hareket.SatisFiyat = SelectedItem.SatisFiyat;
            hareket.KdvOran = SelectedItem.KdvOran;
        }
    }
}
