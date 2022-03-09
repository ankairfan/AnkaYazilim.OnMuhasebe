namespace AnkaYazilim.OnMuhasebe.DTOs.Stoklar;

public class ListStokDto : EntityDto<Guid>
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public int KdvOran { get; set; }
    public string Barkod { get; set; }
    public decimal SatisFiyat { get; set; }
    public decimal AlisFiyat { get; set; }
    public string BirimAdi { get; set; }
    public string OzelKod1Adi { get; set; }
    public string OzelKod2Adi { get; set; }
    public decimal Giren { get; set; }
    public decimal Cikan { get; set; }
    public decimal Mevcut => Giren - Cikan;
    public string Aciklama { get; set; }
}