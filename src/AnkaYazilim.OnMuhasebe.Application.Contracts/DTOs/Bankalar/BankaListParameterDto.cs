namespace AnkaYazilim.OnMuhasebe.DTOs.Bankalar;

public class BankaListParameterDto : PagedResultRequestDto, IDurum, IEntityDto
{
    public bool Durum { get ; set; }
}
