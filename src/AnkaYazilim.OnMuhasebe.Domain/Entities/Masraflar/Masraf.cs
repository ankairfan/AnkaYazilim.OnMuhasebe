namespace AnkaYazilim.OnMuhasebe.Entities.Masraflar;

public class Masraf:FullAuditedAggregateRoot<Guid>
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public byte KdvOran { get; set; }
    public decimal? BirimFiyat { get; set; }
    public Guid BirimId { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }


}
