﻿using AnkaYazilim.OnMuhasebe.DTOs.FaturaHareketler;
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
           SubeId = ((SelectFirmaParametreDto)AppService.FirmaParametre).SubeId,
           DonemId = ((SelectFirmaParametreDto)AppService.FirmaParametre).DonemId,
           Durum = Service.IsActiveCards,
           FaturaHareketler = new List<SelectFaturaHareketDto>()

        };

        Service.ShowEditpage();
        return Task.CompletedTask;

    }

}
