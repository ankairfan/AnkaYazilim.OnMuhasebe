namespace AnkaYazilim.OnMuhasebe.Blazor.Services.Base;

public abstract class BaseService<TDataGridItem, TDataSource> :
    ICoreDataGridService<TDataGridItem>, ICoreEditPageService<TDataSource>,
    ICoreListPageService, ICoreMessageService, ICoreCommonService
    where TDataGridItem : class, IEntityDto<Guid>
    where TDataSource : class, new()

{
    public IStringLocalizerFactory StringLocalizerFactory { get; set; }//property injection
    public IUiMessageService MessageService { get; set; }//property injection
    public ComponentBase DataGrid { get; set; }
    public IList<TDataGridItem> ListDataSource { get; set; }
    public TDataGridItem SelectedItem { get; set; }
    public IEnumerable<TDataGridItem> SelectedItems { get; set; }
    public bool ShowFilterRow { get; set; }
    public bool ShowGroupPanel { get; set; }
    public bool SelectFirstDataRow { get; set; }
    public bool IsLoaded { get; set; }
    public bool ToolbarCheckBoxVisible { get; set; } = true;
    public bool IsActiveCards { get; set; } = true;
    public string LoadingCaption => L["PleaseWait"];
    public string LoadingText => L["Loading"];
    public bool IsPopupListPage { get; set; }
    public bool EditPageVisible { get; set; }
    public Action HasChanged { get; set; }
    public ComponentBase ActiveEditComponent { get; set; }
    public bool ShowSelectionCheckBox { get; set; }
    public TDataSource DataSource { get; set; }
    public Guid PopupListPageFocusedRowId { get; set; }


    public async Task ConfirmMessage(string message, Action action, string title = null)
    {
        var confirmed = await MessageService.Confirm(message, title);
        if (confirmed)
            action();
    }

    public void ShowListPage(bool firstRender)
    {
        if (firstRender)
        {
            SelectFirstDataRow = true;
            return;
        }

        if (PopupListPageFocusedRowId != Guid.Empty)
        {
            SelectFirstDataRow = false;
            SelectedItem = ListDataSource.GetEntityById(PopupListPageFocusedRowId);
            PopupListPageFocusedRowId=Guid.Empty;
        }

        if (SelectFirstDataRow)
        {
            var item = ListDataSource.FirstOrDefault();
            if (item != null && !ShowSelectionCheckBox)
            {
                SetDataRowSelected(item);
            }
            else
            {
                SetDataRowSelected(SelectedItem);
            }
        }
    }

    public void SetDataRowSelected(TDataGridItem item)
    {
        ((DxDataGrid<TDataGridItem>)DataGrid).SetDataRowSelected(item, true);
    }

    public void ShowEditpage()
    {
        SelectFirstDataRow = false;
        EditPageVisible = true;
        HasChanged();
    }

    public void HideEditPage()
    {
        EditPageVisible = false;
        HasChanged();
    }

    public void HideListPage()
    {
        IsPopupListPage = false;
        ShowSelectionCheckBox = false;
        SelectedItems = null;
        ((DxTextBox)ActiveEditComponent)?.FocusAsync();
    }

    public virtual void SelectEntity(IEntityDto targetEntity) { }

    public virtual void BeforeShowPopupListPage(params object[] prm)
    {
        ToolbarCheckBoxVisible = false;
        IsPopupListPage = true;

        if (prm.Length > 0)
            PopupListPageFocusedRowId = prm[0] == null ? Guid.Empty : (Guid)prm[0];


    }

    public virtual void ButtonEditDeleteKeyDown(IEntityDto entity, string fieldName) { }

    public void SetDataRowSelected(bool first)
    {
        ((DxDataGrid<TDataGridItem>)DataGrid).SetDataRowSelected(first?ListDataSource.FirstOrDefault():ListDataSource.LastOrDefault(),true);
    }




    #region Localizer
    private IStringLocalizer _localizer;

    public IStringLocalizer L
    {
        get
        {
            if (_localizer == null)
                _localizer = StringLocalizerFactory.Create(typeof(OnMuhasebeResource));
            return _localizer;

        }
    }


    #endregion


}
