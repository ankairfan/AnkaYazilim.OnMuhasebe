namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class BirimService : BaseService<ListBirimDto, SelectBirimDto>, IScopedDependency
{
    public override void SelectEntity(IEntityDto targetEntity)
    {
        if (targetEntity is SelectHizmetDto hizmet)
        {
            hizmet.BirimId = SelectedItem.Id;
            hizmet.BirimAdi = SelectedItem.Ad;
        }
    }
}