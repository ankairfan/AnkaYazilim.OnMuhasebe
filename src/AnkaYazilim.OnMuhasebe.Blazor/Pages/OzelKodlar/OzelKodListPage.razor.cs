namespace AnkaYazilim.OnMuhasebe.Blazor.Pages.OzelKodlar;

public partial class OzelKodListPage
{
    protected override async Task GetListDataSourceAsync()
    {
        Service.ListDataSource = (await GetListAsync(new OzelKodListParameterDto()
        {
            OzelKodTuru = Service.KodTuru,
            KartTuru = Service.KartTuru,
            Durum = Service.IsActiveCards

        })).Items.ToList();

        Service.IsLoaded = true;
    }

    protected override async Task BeforeInsertAsync()
    {
        Service.DataSource = new SelectOzelKodDto
        {
            Kod = await GetCodeAsync(new OzelKodCodeParameterDto
            {
                OzelKodTuru = Service.KodTuru,
                KartTuru = Service.KartTuru,
                Durum = Service.IsActiveCards
            }),
            KodTuru = Service.KodTuru,
            KartTuru = Service.KartTuru,
            Durum = Service.IsActiveCards
        };

        Service.ShowEditpage();
    }
}
