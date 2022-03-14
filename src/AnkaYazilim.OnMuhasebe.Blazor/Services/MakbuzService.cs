namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class MakbuzService : BaseService<ListMakbuzDto, SelectMakbuzDto>, IScopedDependency
{
    public MakbuzTuru MakbuzTuru { get; set; }

    public override void FillTable<TItem>(ICoreHareketService<TItem> hareketService, Action hasChanged)
    {
        if (hareketService is MakbuzHareketService makbuzHareketService)
        {
            makbuzHareketService.ListDataSource = DataSource.MakbuzHareketler ??
                                                  new List<SelectMakbuzHareketDto>();
            makbuzHareketService.HasChanged = hasChanged;
            makbuzHareketService.GetTotal();
        }
    }
}