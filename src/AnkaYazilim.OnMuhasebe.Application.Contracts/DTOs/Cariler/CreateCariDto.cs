namespace AnkaYazilim.OnMuhasebe.DTOs.Cariler;

public class CreateCariDto:IEntityDto
{
    public string Kod { get; set; }
    public string Unvan { get; set; }
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public string VergiDairesi { get; set; }
    public string VergiNumarasi { get; set; }
    public string TcNumarasi { get; set; }
    public string Adres { get; set; }
    public string Telefon { get; set; }
    public string MobilTelefon { get; set; }
    public string Email { get; set; }
    public string Web { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }
}
