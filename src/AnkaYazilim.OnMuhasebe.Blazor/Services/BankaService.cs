namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class BankaService : BaseService<ListBankaDto, SelectBankaDto>, IScopedDependency
{
    public override void SelectEntity(IEntityDto targetEntity)
    {
        if (targetEntity is SelectBankaHesapDto bankaHesap)
        {
            bankaHesap.BankaId = SelectedItem.Id;
            bankaHesap.BankaAdi = SelectedItem.Ad;
        }

    }
}
