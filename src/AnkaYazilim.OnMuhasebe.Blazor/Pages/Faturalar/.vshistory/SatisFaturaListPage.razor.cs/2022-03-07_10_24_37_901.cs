namespace AnkaYazilim.OnMuhasebe.Blazor.Pages.Faturalar;

public partial class SatisFaturaListPage
{
    public AppService AppService { get; set; }
    protected override async Task GetListDataSourceAsync()
    {
        Service.ListDataSource = (await GetListAsync(new FaturaListParameterDto
        {
            FaturaTuru = FaturaTuru.Alis,
            SubeId = AppService.FirmaParametre.SubeId,
            DonemId = AppService.FirmaParametre.DonemId,
            Durum = Service.IsActiveCards

        })).Items.ToList();

        Service.IsLoaded = true;
    }

    protected override Task BeforeInsertAsync()
    {
        Service.DataSource = new SelectFaturaDto()
        {
            FaturaTuru = FaturaTuru.Alis,
            Tarih = DateTime.Now.Date,
            SubeId = AppService.FirmaParametre.SubeId,
            DonemId = AppService.FirmaParametre.DonemId,
            Durum = Service.IsActiveCards,
            FaturaHareketler = new List<SelectFaturaHareketDto>()

        };

        Service.ShowEditpage();
        return Task.CompletedTask;

    }

}
