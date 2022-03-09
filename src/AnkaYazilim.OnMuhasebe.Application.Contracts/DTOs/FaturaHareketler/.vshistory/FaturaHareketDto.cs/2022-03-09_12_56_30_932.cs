namespace AnkaYazilim.OnMuhasebe.DTOs.FaturaHareketler;

public class FaturaHareketDto : EntityDto<Guid?>
{
    public FaturaHareketTuru? HareketTuru { get; set; }
    public Guid? StokId { get; set; }
    public Guid? HizmetId { get; set; }
    public Guid? MasrafId { get; set; }
    public Guid? DepoId { get; set; }
    public decimal Miktar { get; set; }
    public decimal AlisFiyat { get; set; }
    public decimal SatisFiyat { get; set; }
    public int? IndirimOran { get; set; }
    public int? KdvOran { get; set; }
    public decimal BrutTutar { get; set; }
    public decimal IndirimTutar { get; set; }
    public decimal NetTutar { get; set; }
    public decimal KdvTutar { get; set; }
    public decimal GenelTutar { get; set; }
    public string Aciklama { get; set; }
}