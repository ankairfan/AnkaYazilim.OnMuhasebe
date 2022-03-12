using AnkaYazilim.OnMuhasebe.Makbuzlar;

namespace AnkaYazilim.OnMuhasebe.Blazor.Pages.Makbuzlar;

public partial class TahsilatMakbuzListPage
{
    public AppService AppService { get; set; }//property injection

    protected override async Task GetListDataSourceAsync()
    {
        Service.ListDataSource = (await GetListAsync(new MakbuzListParameterDto
        {
           MakbuzTuru = MakbuzTuru.Tahsilat,
           SubeId = 
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
            FaturaHareketleri = new List<SelectFaturaHareketDto>()
        };

        Service.ShowEditpage();
        return Task.CompletedTask;
    }
}
