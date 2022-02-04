namespace AnkaYazilim.OnMuhasebe.Entities.Stocks.Stoklar;

public class Stok : FullAuditedAggregateRoot<Guid>
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public byte? KdvOran { get; set; }
    public string Barkod { get; set; }
    public decimal? SatisFiyat { get; set; }
    public decimal? AlisFiyat { get; set; }
    public Guid BirimId { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }

    public Birim Birim { get; set; }
    public OzelKod OzelKod1 { get; set; }
    public OzelKod OzelKod2 { get; set; }

    public ICollection<FaturaHareket> FaturaHareketleri { get; set; }

}
