namespace AnkaYazilim.OnMuhasebe.DTOs.Stoklar;

public class StokHareketListParameterDto:PagedResultRequestDto, IDurum, IEntityDto
{
    public FaturaHareketTuru? FaturaHareketTuru { get; set; }
    public Guid EntityId { get; set; }
    public Guid SubeId { get; set; }
    public Guid DonemId { get; set; }
    public bool Durum { get; set; }
}

