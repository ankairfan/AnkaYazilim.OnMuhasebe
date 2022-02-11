namespace AnkaYazilim.OnMuhasebe.DTOs.BankaHesaplar;

public class ListBankaHesapDto : EntityDto<Guid>
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public BankaHesapTuru? HesapTuru { get; set; }
    public string HesapTuruAdi { get; set; }
    public string HesapNo { get; set; }
    public string IBAN { get; set; }
    public string BankaAdi { get; set; }
    public string BankaSubeAdi { get; set; }
    public string OzelKod1Adi { get; set; }
    public string OzelKod2Adi { get; set; }
    public decimal Borc { get; set; }
    public decimal Alacak { get; set; }
    public decimal BorcBakiye => Borc - Alacak > 0 ? Borc - Alacak : 0;
    public decimal AlacakBakiye => Alacak - Borc > 0 ? Alacak - Borc : 0;
    public string Aciklama { get; set; }
    public ICollection<SelectMakbuzHareketDto> MakbuzHareketler { get; set; }

}
