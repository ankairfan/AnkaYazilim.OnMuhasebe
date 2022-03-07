using AnkaYazilim.OnMuhasebe.DTOs.FaturaHareketler;
using AnkaYazilim.OnMuhasebe.Faturalar;

namespace AnkaYazilim.OnMuhasebe.Blazor.Pages.Faturalar;

public partial class SatisFaturaListPage
{
    public AppService AppService { get; set; }
    protected override async Task GetListDataSourceAsync()
    {
        Service.ListDataSource = (await GetListAsync(new FaturaListParameterDto
        {
            FaturaTuru = FaturaTuru.satis,
            SubeId = AppService.FirmaParametre.SubeId,
            DonemId = AppService.FirmaParametre.DonemId,
            Durum = Service.IsActiveCards

        })).Items.ToList();

        Service.IsLoaded = true;
    }

    protected override async Task BeforeInsertAsync()
    {
        Service.DataSource = new SelectFaturaDto()
        {
          FaturaNo = await GetCodeAsync(new FaturaNoParameterDto
          {
              FaturaTuru = FaturaTuru.satis,
              SubeId = AppService.FirmaParametre.SubeId,
              DonemId = AppService.FirmaParametre.DonemId,
              Durum = Service.IsActiveCards
          }),

          FaturaTuru = FaturaTuru.satis,
          Tarih = DateTime.Now.Date,
          SubeId = AppService.FirmaParametre.SubeId,
          DonemId = AppService.FirmaParametre.DonemId,
          Durum = Service.IsActiveCards,
          FaturaHareketler = new List<SelectFaturaHareketDto>()

        };

        Service.ShowEditpage();

    }

}
