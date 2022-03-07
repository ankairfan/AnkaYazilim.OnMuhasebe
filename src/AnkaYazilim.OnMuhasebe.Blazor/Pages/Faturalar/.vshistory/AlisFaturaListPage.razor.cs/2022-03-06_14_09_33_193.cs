using AnkaYazilim.OnMuhasebe.Faturalar;

namespace AnkaYazilim.OnMuhasebe.Blazor.Pages.Faturalar;

public partial class AlisFaturaListPage
{
    public AppService AppService { get; set; }
    protected override async Task GetListDataSourceAsync()
    {
        Service.ListDataSource = (await GetListAsync(new FaturaListParameterDto
        {
            FaturaTuru = FaturaTuru.Alis,
            SubeId = ((SelectFirmaParametreDto)AppService.FirmaParametre).SubeId,
            Durum = Service.IsActiveCards

        })).Items.ToList();

        Service.IsLoaded = true;
    }

    protected override async Task BeforeInsertAsync()
    {
        Service.DataSource = new SelectBankaHesapDto
        {
            Kod = await GetCodeAsync(new BankaHesapCodeParameterDto
            {
                SubeId = ((SelectFirmaParametreDto)AppService.FirmaParametre).SubeId,
                Durum = Service.IsActiveCards
            }),

            HesapTuru = BankaHesapTuru.VadesizMevduatHesabi,
            SubeId = ((SelectFirmaParametreDto)AppService.FirmaParametre).SubeId,
            Durum = Service.IsActiveCards
        };

        Service.ShowEditpage();
    }

}
