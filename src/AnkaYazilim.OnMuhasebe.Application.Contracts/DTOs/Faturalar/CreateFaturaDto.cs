namespace AnkaYazilim.OnMuhasebe.DTOs.Faturalar;

public class CreateFaturaDto : IEntityDto
{
    public FaturaTuru? FaturaTuru { get; set; }
    public string FaturaNo { get; set; }
    public DateTime? Tarih { get; set; }
    public decimal BrutTutar { get; set; }
    public decimal IndirimTutari { get; set; }
    public decimal NetTutar { get; set; }
    public decimal KdvTutar { get; set; }
    public decimal GenelTutar { get; set; }
    public int HareketSayisi { get; set; }
    public Guid? CariId { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public Guid? SubeId { get; set; }
    public Guid? DonemId { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }
    public ICollection<FaturaHareketDto> FaturaHareketleri { get; set; }
}