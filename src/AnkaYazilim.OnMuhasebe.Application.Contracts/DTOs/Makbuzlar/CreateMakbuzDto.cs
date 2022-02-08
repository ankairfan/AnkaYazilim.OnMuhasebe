namespace AnkaYazilim.OnMuhasebe.DTOs.Makbuzlar;

public class CreateMakbuzDto:IEntityDto
{
    public MakbuzTuru? MakbuzTuru { get; set; }
    public string MakbuzNo { get; set; }
    public DateTime? Tarih { get; set; }
    public Guid? CariId { get; set; }
    public Guid? KasaId { get; set; }
    public Guid? BankaHesapId { get; set; }
    public int HareketSayisi { get; set; }
    public decimal? CekToplamTutar { get; set; }
    public decimal? SenetToplamTutar { get; set; }
    public decimal? PosToplamTutar { get; set; }
    public decimal? NakitToplamTutar { get; set; }
    public decimal? BankaToplamTutar { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public Guid? SubeId { get; set; }
    public Guid? DonemId { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }
    public ICollection<MakbuzHareketDto> MakbuzHareketler { get; set; }
}
