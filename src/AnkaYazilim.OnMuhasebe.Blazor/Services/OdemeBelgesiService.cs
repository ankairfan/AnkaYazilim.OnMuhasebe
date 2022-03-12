using AnkaYazilim.OnMuhasebe.DTOs.OdemeBelgeleri;

namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class OdemeBelgesiService:BaseService<ListOdemeBelgesiDto,SelectMakbuzHareketDto>,IScopedDependency
{
    public AppService AppService { get; set; }
    public MakbuzService MakbuzService { get; set; }
}