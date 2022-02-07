namespace AnkaYazilim.OnMuhasebe.DTOs.Cariler;

public class CariListParameterDto:PagedResultRequestDto, IDurum,IEntityDto
{
    public bool Durum { get; set; }
}
