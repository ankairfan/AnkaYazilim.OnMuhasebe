namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class SubeService : BaseService<ListSubeDto, SelectSubeDto>, IScopedDependency
{
    public override void SelectEntity(IEntityDto targetEntity)
    {
        switch (targetEntity)
        {
            case SelectFirmaParametreDto firmaParametre:
                firmaParametre.SubeId = SelectedItem.Id;
                firmaParametre.SubeAdi = SelectedItem.Ad;
                break;
        }
    }
}
