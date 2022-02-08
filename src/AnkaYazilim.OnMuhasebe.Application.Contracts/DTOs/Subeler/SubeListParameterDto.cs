namespace AnkaYazilim.OnMuhasebe.DTOs.Subeler;

public class SubeListParameterDto : PagedResultRequestDto, IDurum, IEntityDto
{
    public bool Durum { get; set; }
}
