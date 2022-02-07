namespace AnkaYazilim.OnMuhasebe.DTOs.BankaSubeler;

public class BankaSubeListParameterDto : PagedResultRequestDto, IDurum, IEntityDto
{
    public Guid BankaId { get; set; }
    public bool Durum { get ; set ; }
}
