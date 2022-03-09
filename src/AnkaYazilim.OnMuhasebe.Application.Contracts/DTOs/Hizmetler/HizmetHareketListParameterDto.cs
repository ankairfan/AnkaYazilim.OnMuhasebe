namespace AnkaYazilim.OnMuhasebe.DTOs.Hizmetler;

public class HizmetHareketListParameterDto : PagedResultRequestDto, IDurum, IEntityDto
{
    public Guid HizmetId { get; set; }
    public FaturaHareketTuru HareketTuru { get; set; }
    public Guid SubeId { get; set; }
    public Guid DonemId { get; set; }
    public bool Durum { get; set; }
}