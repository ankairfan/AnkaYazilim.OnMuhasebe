namespace AnkaYazilim.OnMuhasebe.DTOs.Makbuzlar;

public class MakbuzReportDto:IEntityDto
{
    public string MakbuzNo { get; set; }
    public DateTime? Tarih { get; set; }
    public string CariKodu { get; set; }
    public string CariAdi { get; set; }
    public string KasaAdi { get; set; }
    public string BankaHesapAdi { get; set; }
    public decimal? CekToplamTutar { get; set; }
    public decimal? SenetToplamTutar { get; set; }
    public decimal? PosToplamTutar { get; set; }
    public decimal? NakitToplamTutar { get; set; }
    public decimal? BankaToplamTutar { get; set; }
    public decimal? GenelToplam => CekToplamTutar + SenetToplamTutar + PosToplamTutar + NakitToplamTutar + BankaToplamTutar;
    public string SubeAdi { get; set; }
    public string Aciklama { get; set; }
    public List<MakbuzHareketReportDto> MakbuzHareketler { get; set; }

}
