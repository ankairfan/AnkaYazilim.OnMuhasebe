namespace AnkaYazilim.OnMuhasebe.Blazor.Pages.OdemeBelgeleri;

public partial class OdemeBelgeleriListPage
{
    protected override async Task GetListDataSourceAsync()
    {
        if (!Service.IsPopupListPage)
        {
            Service.MakbuzService.MakbuzTuru = 0;
        }
    }
}