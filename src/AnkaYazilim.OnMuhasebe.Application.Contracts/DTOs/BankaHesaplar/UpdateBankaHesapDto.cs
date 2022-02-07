namespace AnkaYazilim.OnMuhasebe.DTOs.BankaHesaplar;

public class UpdateBankaHesapDto : IEntityDto
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public BankaHesapTuru? HesapTuru { get; set; }
    public string HesapNo { get; set; }
    public string IBAN { get; set; }
    public Guid? BankaSubeId { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }
}
