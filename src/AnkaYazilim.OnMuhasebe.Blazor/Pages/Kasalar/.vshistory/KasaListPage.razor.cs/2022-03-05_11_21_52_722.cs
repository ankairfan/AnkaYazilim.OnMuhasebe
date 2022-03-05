namespace AnkaYazilim.OnMuhasebe.Blazor.Pages.Kasalar;

public partial class KasaListPage
{
    public AppService AppService { get; set; }

    protected override async Task GetListDataSourceAsync()
    {
        Service.ListDataSource = (await GetListAsync(new KasaListParameterDto
        {
            SubeId = ((SelectFirmaParametreDto)AppService.FirmaParametre).SubeId,
            Durum = Service.IsActiveCards
        })).Items.ToList();

        Service.IsLoaded = true;
    }

    protected override async Task BeforeInsertAsync()
    {
        Service.DataSource = new SelectDepoDto
        {
            Kod = await GetCodeAsync(new DepoCodeParameterDto
            {
                SubeId = ((SelectFirmaParametreDto)AppService.FirmaParametre).SubeId,
                Durum = Service.IsActiveCards
            }),

            SubeId = ((SelectFirmaParametreDto)AppService.FirmaParametre).SubeId,
            Durum = Service.IsActiveCards
        };

        Service.ShowEditpage();
    }
}