namespace AnkaYazilim.OnMuhasebe.DTOs.Hizmetler;

public class HizmetListParameterDto:PagedResultRequestDto, IDurum, IEntityDto
{
    public bool Durum { get; set; }
}
