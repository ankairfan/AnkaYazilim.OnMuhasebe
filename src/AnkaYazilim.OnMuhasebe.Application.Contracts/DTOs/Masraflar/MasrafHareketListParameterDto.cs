namespace AnkaYazilim.OnMuhasebe.DTOs.Masraflar;

public class MasrafHareketListParameterDto : PagedResultRequestDto, IDurum, IEntityDto
{
    public Guid MasrafId { get; set; }
    public FaturaHareketTuru HareketTuru { get; set; }
    public Guid SubeId { get; set; }
    public Guid DonemId { get; set; }
    public bool Durum { get; set; }
}