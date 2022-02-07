namespace AnkaYazilim.OnMuhasebe.DTOs.Birimler;

public class UpdateBirimDto:IEntityDto
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public string Aciklama { get; set; }
}
