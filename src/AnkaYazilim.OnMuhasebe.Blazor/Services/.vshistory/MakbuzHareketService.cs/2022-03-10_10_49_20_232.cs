namespace AnkaYazilim.OnMuhasebe.Blazor.Services.Base;

public class MakbuzHareketService : BaseHareketService<SelectMakbuzHareketDto>, IScopedDependency
{
    public MakbuzService FaturaService { get; set; }//property injection
    public AppService AppService { get; set; }//property injection
}
