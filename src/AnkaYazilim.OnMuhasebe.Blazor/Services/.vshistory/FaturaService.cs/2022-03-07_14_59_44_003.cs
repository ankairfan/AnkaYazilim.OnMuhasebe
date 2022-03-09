namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class FaturaService : BaseService<ListFaturaDto, SelectFaturaDto>, IScopedDependency
{
    public override void FillTable<TItem>(ICoreHareketService<TItem> hareketService, Action hasChanged)
    {
        base.FillTable(hareketService, hasChanged);
    }
}