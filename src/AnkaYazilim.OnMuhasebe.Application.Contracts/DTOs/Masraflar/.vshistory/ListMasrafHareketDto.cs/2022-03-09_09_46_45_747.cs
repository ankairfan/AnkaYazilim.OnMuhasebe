namespace AnkaYazilim.OnMuhasebe.DTOs.Masraflar;

public class ListMasrafHareketDto : EntityDto<Guid>
{
    public Guid? MasrafId { get; set; }
    public Guid? FaturaId { get; set; }
    public DateTime Tarih { get; set; }
    public string BelgeNo { get; set; }
    public FaturaTuru FaturaTuru { get; set; }
    public string BelgeTuru { get; set; }
    public FaturaHareketTuru HareketTuru { get; set; }
    public string HareketTuruAdi { get; set; }
    public string Aciklama { get; set; }
    public decimal Miktar { get; set; }
    public string Birim { get; set; }
    public decimal AlisFiyat { get; set; }
    public decimal SatisFiyat { get; set; }
    public decimal Tutar { get; set; }
}