namespace AnkaYazilim.OnMuhasebe.Blazor.Pages.Makbuzlar;

public partial class OdemeMakbuzLisPage
{
    public AppService AppService { get; set; }//property injection

    protected override async Task GetListDataSourceAsync()
    {
        var listDataSource = (await GetListAsync(new MakbuzListParameterDto
        {
            MakbuzTuru = MakbuzTuru.Odeme,
            SubeId = AppService.FirmaParametre.SubeId,
            DonemId = AppService.FirmaParametre.DonemId,
            Durum = Service.IsActiveCards
        }))?.Items.ToList();

        Service.IsLoaded = true;

        if (listDataSource != null)
            Service.ListDataSource = listDataSource;
    }

    protected override async Task BeforeInsertAsync()
    {
        Service.DataSource = new SelectMakbuzDto
        {
            MakbuzNo = await GetCodeAsync(new MakbuzNoParameterDto
            {
                MakbuzTuru = MakbuzTuru.Odeme,
                SubeId = AppService.FirmaParametre.SubeId,
                DonemId = AppService.FirmaParametre.DonemId,
                Durum = Service.IsActiveCards
            }),

            MakbuzTuru = MakbuzTuru.Odeme,
            Tarih = DateTime.Now.Date,
            SubeId = AppService.FirmaParametre.SubeId,
            DonemId = AppService.FirmaParametre.DonemId,
            Durum = Service.IsActiveCards,
            MakbuzHareketler = new List<SelectMakbuzHareketDto>()
        };

        Service.ShowEditpage();
        await Task.CompletedTask;
    }
}
