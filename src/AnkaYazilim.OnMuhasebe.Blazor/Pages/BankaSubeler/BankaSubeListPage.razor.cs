namespace AnkaYazilim.OnMuhasebe.Blazor.Pages.BankaSubeler;

public partial class BankaSubeListPage
{
    protected override async Task GetListDataSourceAsync()
    {
        Service.ListDataSource = (await GetListAsync(new BankaSubeListParameterDto()
        {
            BankaId = Service.BankaId,
            Durum = Service.IsActiveCards

        })).Items.ToList();

        Service.IsLoaded = true;
    }

    protected override async Task BeforeInsertAsync()
    {
        Service.DataSource = new SelectBankaSubeDto
        {
            Kod = await GetCodeAsync(new BankaSubeCodeParametreDto
            {
                BankaId = Service.BankaId,
                Durum = Service.IsActiveCards
            }),
            BankaId = Service.BankaId,
            Durum = Service.IsActiveCards
        };

        Service.ShowEditpage();
    }

}
