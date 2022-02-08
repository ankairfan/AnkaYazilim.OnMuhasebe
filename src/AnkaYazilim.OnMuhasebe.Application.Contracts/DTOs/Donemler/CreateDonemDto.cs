namespace AnkaYazilim.OnMuhasebe.DTOs.Donemler;

public class CreateDonemDto:IEntityDto
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }
}
