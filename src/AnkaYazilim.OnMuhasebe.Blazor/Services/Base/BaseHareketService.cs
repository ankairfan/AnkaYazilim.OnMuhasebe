using Volo.Abp.Guids;

namespace AnkaYazilim.OnMuhasebe.Blazor.Services.Base;

public abstract class BaseHareketService<TDataGridItem> : ICoreHareketService<TDataGridItem>
{
    public ComponentBase DataGrid { get; set; }
    public IUiMessageService MessageService { get; set; }//property injection
    public IGuidGenerator GuidGenerator { get; set; }//property injection
    public IStringLocalizerFactory StringLocalizerFactory { get; set; }//property injection
    public IList<TDataGridItem> ListDataSource { get; set; }
    public TDataGridItem SelectedItem { get; set; }
    public IEnumerable<TDataGridItem> SelectedItems { get; set; }
    public bool ShowFilterRow { get; set; }
    public bool ShowGroupPanel { get; set; }
    public bool SelectFirstDataRow { get; set; }
    public bool IsLoaded { get; set; }
    public bool ShowSelectionCheckBox { get; set; }
    public Guid PopupListPageFocusedRowId { get; set; }
    public IList<string> ExcludeListItems { get; set; }

    public void ShowListPage(bool firstRender)
    {
        throw new NotImplementedException();
    }

    public void SetDataRowSelected(TDataGridItem item)
    {
        ((DxDataGrid<TDataGridItem>)DataGrid).SetDataRowSelected(item, true);
    }

    public void SetDataRowSelected(bool first)
    {
        ((DxDataGrid<TDataGridItem>)DataGrid).SetDataRowSelected(
            first ? ListDataSource.FirstOrDefault() :
                ListDataSource.LastOrDefault(), true);
    }
    public TDataGridItem DataSource { get; set; }

    public void ButtonEditDeleteKeyDown(IEntityDto entity, string fieldName)
    {
        throw new NotImplementedException();
    }

    public bool ToolbarCheckBoxVisible { get; set; }
    public bool IsActiveCards { get; set; }
    public string LoadingCaption { get; }
    public string LoadingText { get; }
    public bool IsPopupListPage { get; set; }
    public bool EditPageVisible { get; set; }
    public TDataGridItem TempDataSource { get; set; }

    public void ShowEditpage()
    {
        throw new NotImplementedException();
    }

    public void HideEditPage()
    {
        EditPageVisible = false;
        HasChanged();
    }

    public void HideListPage()
    {
        throw new NotImplementedException();
    }

    public void SelectEntity(IEntityDto targetEntity)
    {
        throw new NotImplementedException();
    }

    public void BeforeShowPopupListPage(params object[] prm)
    {
        throw new NotImplementedException();
    }

    public async Task ConfirmMessage(string message, Action action, string title = null)
    {
        var confirmed = await MessageService.Confirm(message, title);
        if (confirmed)
            action();
    }

    public virtual void FillTable<TItem>(ICoreHareketService<TItem> hareketService, Action hasChanged)
    { }

    public virtual void GetTotal()
    { }

    public virtual void BeforeUpdate()
    {
        DataSource = SelectedItem;
        EditPageVisible = true;
    }

    public virtual void BeforeInsert()
    { }

    public virtual async Task DeleteAsync()
    {
        await ConfirmMessage(L["DeleteConfirmMessage"], async () =>
        {
            var deletedEntityIndex = ListDataSource.FindIndex(x => x.GetEntityId() == SelectedItem.GetEntityId());
            ListDataSource.Remove(SelectedItem);
            await ((DxDataGrid<TDataGridItem>)DataGrid).Refresh();

            SelectedItem = ListDataSource.SetSelectedItem(deletedEntityIndex);
            SetDataRowSelected(SelectedItem);
            GetTotal();
            HasChanged();
        }, L["DeleteConfirmMessageTitle"]);
    }

    public virtual void OnSubmit()
    { }

    public virtual void InsertOrUpdate()
    {
        if (((IEntityDto<Guid>)DataSource).Id == Guid.Empty)
        {
            ((IEntityDto<Guid>)DataSource).Id = GuidGenerator.Create();
            ListDataSource.Add(DataSource);
        }
        else
        {
            var itemIndex = ListDataSource.FindIndex(x => ((IEntityDto<Guid>)x).Id == ((IEntityDto<Guid>)SelectedItem).Id);
            ListDataSource[itemIndex] = DataSource;
        }
        EditPageVisible = false;
        SetDataRowSelected(DataSource);
        GetTotal();
    }

    public virtual void Hesapla(object value, string propertyName)
    {
    }

    public void AddSelectedItems()
    {
        throw new NotImplementedException();
    }

    public Action HasChanged { get; set; }
    public ComponentBase ActiveEditComponent { get; set; }

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

    #endregion Localizer
}