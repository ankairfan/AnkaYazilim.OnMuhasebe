namespace AnkaYazilim.OnMuhasebe.DTOs.OzelKodlar;

public class OzelKodCodeParameterDto:IDurum,IEntityDto
{
    public OzelKodTuru OzelKodTuru { get; set; }
    public KartTuru KartTuru { get; set; }
    public bool Durum { get; set; }
}
