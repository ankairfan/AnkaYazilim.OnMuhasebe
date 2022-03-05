namespace AnkaYazilim.OnMuhasebe.DTOs.Kasalar;

public class KasaCodeParameterDto:IDurum,IEntityDto
{
    public Guid SubeId { get; set; }
    public bool Durum { get; set; }
}
