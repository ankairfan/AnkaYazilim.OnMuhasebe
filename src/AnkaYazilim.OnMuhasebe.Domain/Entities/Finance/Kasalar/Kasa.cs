namespace AnkaYazilim.OnMuhasebe.Entities.Finance.Kasalar;

public class Kasa:FullAuditedAggregateRoot<Guid>
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public string Aciklama { get; set; }
    public Guid SubeId { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public bool Durum { get; set; }
}
