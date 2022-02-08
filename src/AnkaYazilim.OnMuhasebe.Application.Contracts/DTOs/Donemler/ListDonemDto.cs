namespace AnkaYazilim.OnMuhasebe.DTOs.Donemler;

public class ListDonemDto:EntityDto<Guid>
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public string Aciklama { get; set; }
}
