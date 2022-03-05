namespace AnkaYazilim.OnMuhasebe.DTOs.Stoklar;

public class CreateStokDto : IEntityDto
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public int KdvOran { get; set; }
    public string Barkod { get; set; }
    public decimal SatisFiyat { get; set; }
    public decimal AlisFiyat { get; set; }
    public Guid? BirimId { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }
}