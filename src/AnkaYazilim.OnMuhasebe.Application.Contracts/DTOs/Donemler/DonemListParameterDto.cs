namespace AnkaYazilim.OnMuhasebe.DTOs.Donemler;

public class DonemListParameterDto : PagedResultRequestDto, IDurum, IEntityDto
{
    public bool Durum { get; set; }
}
