namespace AnkaYazilim.OnMuhasebe.DTOs.BankaHesaplar;

public class BankaHesapListParameterDto : PagedResultRequestDto, IEntityDto, IDurum
{
    public BankaHesapTuru? HesapTuru { get; set; }
    public Guid? SubeId { get; set; }
    public bool Durum { get; set; }
}
