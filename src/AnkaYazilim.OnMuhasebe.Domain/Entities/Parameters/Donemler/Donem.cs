namespace AnkaYazilim.OnMuhasebe.Entities.Parameters.Donemler;

public class Donem : FullAuditedAggregateRoot<Guid>
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }

    public ICollection<Fatura> Faturalar { get; set; }
    public ICollection<Makbuz> Makbuzlar { get; set; }
    public ICollection<FirmaParametreleri> FirmaParametreleri { get; set; }

}
