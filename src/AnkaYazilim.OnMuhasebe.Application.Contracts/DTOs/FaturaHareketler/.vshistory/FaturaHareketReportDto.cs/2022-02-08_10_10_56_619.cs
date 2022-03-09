namespace AnkaYazilim.OnMuhasebe.DTOs.FaturaHareketler;

public class FaturaHareketReportDto:EntityDto<Guid>
{
    public string HareketTuru { get; set; }
    public string HareketAdi { get; set; }
    public string HareketKodu { get; set; }
    public string StokKodu { get; set; }
    public string StokAdi { get; set; }
    public string HizmetKodu { get; set; }
    public string HizmetAdi { get; set; }
    public string MasrafKodu { get; set; }
    public string MasrafAdi { get; set; }
    public string DepoKodu { get; set; }
    public string DepoAdi { get; set; }
    public string BirimAdi { get; set; }
    public decimal Miktar { get; set; }
    public decimal Fiyat { get; set; }
    public byte? IndirimOran { get; set; }
    public byte? KdvOran { get; set; }
    public decimal BrutTutar { get; set; }
    public decimal? IndirimTutar { get; set; }
    public decimal NetTutar { get; set; }
    public decimal? KdvTutar { get; set; }
    public decimal GenelTutar { get; set; }
    public string Aciklama { get; set; }

}
