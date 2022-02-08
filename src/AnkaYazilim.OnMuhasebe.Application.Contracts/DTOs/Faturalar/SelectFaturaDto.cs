namespace AnkaYazilim.OnMuhasebe.DTOs.Faturalar;

public class SelectFaturaDto:EntityDto<Guid>, IOzelKod
{
    public FaturaTuru? FaturaTuru { get; set; }
    public string FaturaNo { get; set; }
    public DateTime? Tarih { get; set; }
    public Guid? CariId { get; set; }
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
    public Guid? OzelKod1Id { get; set; }
    public string OzelKod1Adi { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public string OzelKod2Adi { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }
    public Guid? SubeId { get; set; }
    public Guid? DonemId { get; set; }
    public List<SelectFaturaHareketDto> FaturaHareketler { get; set; }
}

