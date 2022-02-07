namespace AnkaYazilim.OnMuhasebe.DTOs.Birimler;

public class BirimListParameterDto : PagedResultRequestDto, IDurum, IEntityDto
{
    public bool Durum { get ; set ; }
}
