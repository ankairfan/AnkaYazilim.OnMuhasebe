namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class MakbuzService : BaseService<ListMakbuzDto, SelectMakbuzDto>, IScopedDependency
{
    public MakbuzTuru MakbuzTuru { get; set; }

}
