namespace AnkaYazilim.OnMuhasebe.DTOs.BankaHesaplar;

public class BankaHesapCodeParameterDto:IEntityDto, IDurum
{
    public Guid SubeId { get; set; }
    public bool Durum { get; set; }

}
