namespace AnkaYazilim.OnMuhasebe.DTOs.BankaSubeler;

public class BankaSubeCodeParametreDto : IDurum, IEntityDto
{
    public Guid BankaId { get; set; }
    public bool Durum { get; set ; }
}
