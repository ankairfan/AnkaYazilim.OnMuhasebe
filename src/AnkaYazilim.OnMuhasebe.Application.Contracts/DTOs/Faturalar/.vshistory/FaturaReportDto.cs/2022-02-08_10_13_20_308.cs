using AnkaYazilim.OnMuhasebe.DTOs.FaturaHareketler;

namespace AnkaYazilim.OnMuhasebe.DTOs.Faturalar;

public class FaturaReportDto:IEntityDto
{
    public string FaturaNo { get; set; }
    public DateTime? Tarih { get; set; }
    public string CariAdi { get; set; }
    public string VergiDairesi { get; set; }
    public string VergiNumarasi { get; set; }
    public string TcNumarasi { get; set; }
    public string Adres { get; set; }
    public string TelefonNumarasi { get; set; }
    public decimal? BrutTutar { get; set; }
    public decimal? IndirimTutari { get; set; }
    public decimal? NetTutar { get; set; }
    public decimal? KdvTutar { get; set; }
    public decimal? GenelTutar { get; set; }
    public int? HareketSayisi { get; set; }
    public string Aciklama { get; set; }
    public List<FaturaHareketReportDto> FaturaHareketler { get; set; }

}
