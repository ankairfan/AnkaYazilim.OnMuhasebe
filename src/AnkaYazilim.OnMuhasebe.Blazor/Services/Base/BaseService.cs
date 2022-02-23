namespace AnkaYazilim.OnMuhasebe.Blazor.Services.Base;

public abstract class BaseService<TDataGridItem, TDataSource> :
    ICoreDataGridService<TDataGridItem>, ICoreEditPageService<TDataSource>,
    ICoreListPageService, ICoreMessageService, ICoreCommonService
    where TDataGridItem : class, IEntityDto<Guid>
    where TDataSource : class, new()

{
    public ComponentBase DataGrid { get; set; }
    public IList<TDataGridItem> DataSource { get; set; }
    public TDataGridItem SelectedItem { get; set; }
    public IEnumerable<TDataGridItem> SelectedItems { get; set; }
    public bool ShowFilterRow { get; set; }
    public bool ShowGroupPanel { get; set; }
    public bool SelectFirstDataRow { get; set; }
    public bool IsLoaded { get; set; }
    public bool ToolbarCheckBoxVisible { get; set; }
    public bool IsActiveCards { get; set; }
    public string LoadingCaption { get; set; }
    public string LoadingText { get; set; }
    public bool IsPopUpListPage { get; set; }
    public bool EditPageVisible { get; set; }
    public Action HasChanged { get; set; }
    public ComponentBase ActiveEditComponent { get; set; }
}
