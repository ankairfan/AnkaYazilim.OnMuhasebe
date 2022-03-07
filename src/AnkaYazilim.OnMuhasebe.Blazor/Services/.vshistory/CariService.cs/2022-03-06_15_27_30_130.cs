namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class CariService : BaseService<ListCariDto, SelectCariDto>, IScopedDependency
{
    public override void SelectEntity(IEntityDto targetEntity)
    {
        switch (targetEntity)
        {
            case SelectFaturaDto fatura:
                fatura.CariId = SelectedItem.Id;
                fatura.Unvan = SelectedItem.Ad;
                break;
        }
    }
}
