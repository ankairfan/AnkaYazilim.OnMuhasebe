namespace AnkaYazilim.OnMuhasebe.DTOs.Faturalar;

public class ListFaturaDto:EntityDto<Guid>
{
    public string FaturaNo { get; set; }
    public DateTime Tarih { get; set; }
    public string Unvan { get; set; }
    public decimal BrutTutar { get; set; }
    public decimal IndirimTutari { get; set; }
    public decimal NetTutar { get; set; }
    public decimal KdvTutar { get; set; }
    public decimal GenelTutar { get; set; }
    public int HareketSayisi { get; set; }
    public string OzelKod1Adi { get; set; }
    public string OzelKod2Adi { get; set; }
    public string Aciklama { get; set; }
}

