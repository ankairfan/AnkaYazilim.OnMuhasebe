namespace AnkaYazilim.OnMuhasebe.DTOs.Makbuzlar;

public class ListMakbuzDto : EntityDto<Guid>
{
    public string MakbuzNo { get; set; }
    public DateTime Tarih { get; set; }
    public string Unvan { get; set; }
    public string KasaAdi { get; set; }
    public string BankaHesapAdi { get; set; }
    public int HareketSayisi { get; set; }
    public decimal? CekToplamTutar { get; set; }
    public decimal? SenetToplamTutar { get; set; }
    public decimal? PosToplamTutar { get; set; }
    public decimal? NakitToplamTutar { get; set; }
    public decimal? BankaToplamTutar { get; set; }
    public decimal? GenelToplam => CekToplamTutar + SenetToplamTutar + PosToplamTutar + NakitToplamTutar + BankaToplamTutar;
    public string OzelKod1Adi { get; set; }
    public string OzelKod2Adi { get; set; }
    public string Aciklama { get; set; }
}
