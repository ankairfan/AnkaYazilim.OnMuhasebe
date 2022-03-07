namespace AnkaYazilim.OnMuhasebe.DTOs.Parametreler;

public class SelectFirmaParametreDto:EntityDto<Guid>
{
    public Guid SubeId { get; set; }
    public string SubeAdi { get; set; }
    public Guid DonemId { get; set; }
    public string DonemAdi { get; set; }
    public Guid DepoId { get; set; }
    public string DepoAdi { get; set; }
}
