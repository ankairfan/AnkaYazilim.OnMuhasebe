namespace AnkaYazilim.OnMuhasebe.DTOs.Depolar;

public class DepoListParameterDto:PagedResultRequestDto, IDurum, IEntityDto
{
    public Guid SubeId { get; set; }
    public bool Durum { get; set; }
}
