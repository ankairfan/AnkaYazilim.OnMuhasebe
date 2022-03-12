namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class DonemService : BaseService<ListDonemDto, SelectDonemDto>, IScopedDependency
{
    public override void SelectEntity(IEntityDto targetEntity)
    {
        switch (targetEntity)
        {
            case SelectFirmaParametreDto firmaParametre:
                firmaParametre.DonemId = SelectedItem.Id;
                firmaParametre.DonemAdi = SelectedItem.Ad;
                break;
        }
    }
}
