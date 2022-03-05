namespace AnkaYazilim.OnMuhasebe.DTOs.Kasalar;

public class KasaListParameterDto : PagedResultRequestDto, IDurum, IEntityDto
{
    public Guid? SubeId { get; set; }
    public bool Durum { get; set; }
}