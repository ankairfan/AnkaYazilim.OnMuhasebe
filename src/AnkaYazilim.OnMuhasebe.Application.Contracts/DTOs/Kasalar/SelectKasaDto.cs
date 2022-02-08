namespace AnkaYazilim.OnMuhasebe.DTOs.Kasalar;

public class SelectKasaDto:EntityDto<Guid>, IOzelKod
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public string Aciklama { get; set; }
    public Guid? SubeId { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public string OzelKod1Adi { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public string OzelKod2Adi { get; set; }
    public bool Durum { get; set; }
}
