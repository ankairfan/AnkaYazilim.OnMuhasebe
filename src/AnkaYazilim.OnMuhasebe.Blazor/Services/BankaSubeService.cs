namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class BankaSubeService : BaseService<ListBankaSubeDto, SelectBankaSubeDto>, IScopedDependency
{
    public Guid BankaId { get; set; }

    public override void BeforeShowPopupListPage(params object[] prm)
    {
        ToolbarCheckBoxVisible = prm.Length == 1;
        IsPopupListPage = true;
        BankaId = (Guid)prm[0];
        PopupListPageFocusedRowId = prm.Length > 1 && prm[1] != null ? (Guid)prm[1] :
            Guid.Empty;
    }

    public override void SelectEntity(IEntityDto targetEntity)
    {
        if (targetEntity is SelectBankaHesapDto bankaHesap)
        {
            bankaHesap.BankaSubeId = SelectedItem.Id;
            bankaHesap.BankaSubeAdi = SelectedItem.Ad;
        }

    }
}
