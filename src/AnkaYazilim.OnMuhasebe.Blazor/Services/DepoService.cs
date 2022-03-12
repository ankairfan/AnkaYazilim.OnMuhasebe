namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class DepoService : BaseService<ListDepoDto, SelectDepoDto>, IScopedDependency
{
    public override void SelectEntity(IEntityDto targetEntity)
    {
        switch (targetEntity)
        {
            case SelectFirmaParametreDto firmaParametre:
                firmaParametre.DepoId = SelectedItem.Id;
                firmaParametre.DepoAdi = SelectedItem.Ad;
                break;

            case SelectFaturaHareketDto faturaHareket:
                faturaHareket.DepoId = SelectedItem.Id;
                faturaHareket.DepoAdi = SelectedItem.Ad;
                break;
        }
    }
}