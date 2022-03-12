﻿using AnkaYazilim.OnMuhasebe.DTOs.OdemeBelgeleri;
using DevExpress.Blazor.Internal;

namespace AnkaYazilim.OnMuhasebe.Blazor.Pages.OdemeBelgeleri;

public partial class OdemeBelgeleriListPage
{
    public AppService AppService { get; set; }

    protected override async Task GetListDataSourceAsync()
    {
        if (!Service.IsPopupListPage)
        {
            Service.MakbuzService.MakbuzTuru = 0;
            Service.OdemeTurleri = $"{(byte)OdemeTuru.Cek},{(byte)OdemeTuru.Senet},{(byte)OdemeTuru.Pos}";
            Service.KendiBelgemiz = false;
        }

        Service.ListDataSource = (await GetListAsync(new OdemeBelgesiListParameterDto
        {
            Sql = Service.MakbuzService.MakbuzTuru == MakbuzTuru.BankaIslem ||
                  Service.MakbuzService.MakbuzTuru == MakbuzTuru.KasaIslem ? "IslemYapilabilecekTumOdemeBelgeleri" :
                Service.MakbuzService.MakbuzTuru == MakbuzTuru.Odeme ? "IslemYapilabilecekOdemeBelgeleri" :
                "OdemeBelgeleri",
            SubeId = AppService.FirmaParametre.SubeId,
            DonemId = AppService.FirmaParametre.DonemId,
            KendiBelgemiz = Service.KendiBelgemiz,
            OdemeTurleri = Service.OdemeTurleri
        })).Items.ToList();

        Service.ExcludeListItems.ForEach(x =>
        {
            var entity = Service.ListDataSource.FirstOrDefault(y => y.TakipNo == x);
            Service.ListDataSource.Remove(entity);
        });

        Service.ExcludeListItems = null;
        Service.IsLoaded = true;
    }
}