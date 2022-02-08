namespace AnkaYazilim.OnMuhasebe.DTOs.Makbuzlar;

public class SelectMakbuzDto : EntityDto<Guid>, IOzelKod
{
    public MakbuzTuru? MakbuzTuru { get; set; }
    public string MakbuzNo { get; set; }
    public DateTime? Tarih { get; set; }
    public Guid? CariId { get; set; }
    public string CariKodu { get; set; }
    public string CariAdi { get; set; }
    public Guid? KasaId { get; set; }
    public string KasaAdi { get; set; }
    public Guid? BankaHesapId { get; set; }
    public string BankaHesapAdi { get; set; }
    public int HareketSayisi { get; set; }
    public decimal? CekToplamTutar { get; set; }
    public decimal? SenetToplamTutar { get; set; }
    public decimal? PosToplamTutar { get; set; }
    public decimal? NakitToplamTutar { get; set; }
    public decimal? BankaToplamTutar { get; set; }
    public decimal? GenelToplam => CekToplamTutar + SenetToplamTutar + PosToplamTutar + NakitToplamTutar + BankaToplamTutar;
    public Guid? OzelKod1Id { get; set; }
    public string OzelKod1Adi { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public string OzelKod2Adi { get; set; }
    public Guid? SubeId { get; set; }
    public string SubeAdi { get; set; }
    public Guid? DonemId { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }
    public List<SelectMakbuzHareketDto> MakbuzHareketler { get; set; }
}

