namespace AnkaYazilim.OnMuhasebe.DTOs.Cariler;

public class ListCariDto : EntityDto<Guid>
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
    public string OzelKod1Adi { get; set; }
    public string OzelKod2Adi { get; set; }
    public decimal? Borc { get; set; }
    public decimal? Alacak { get; set; }
    public decimal? BorcBakiye => Borc - Alacak > 0 ? Borc - Alacak : 0;
    public decimal? AlacakBakiye => Alacak - Borc > 0 ? Alacak - Borc : 0;
    public string Aciklama { get; set; }
    public ICollection<SelectFaturaDto> Faturalar { get; set; }
    public ICollection<SelectMakbuzDto> Makbuzlar { get; set; }
}