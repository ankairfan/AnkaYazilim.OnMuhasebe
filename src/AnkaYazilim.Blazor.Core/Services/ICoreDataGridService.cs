using Microsoft.AspNetCore.Components;

namespace AnkaYazilim.Blazor.Core.Services;

public interface ICoreDataGridService<TDataGridItem>
{
    public ComponentBase DataGrid { get; set; }
    public IList<TDataGridItem> DataSource { get; set; }
    public TDataGridItem SelectedItem { get; set; }
    public IEnumerable<TDataGridItem> SelectedItems { get; set; }
    public bool ShowFilterRow { get; set; }
    public bool ShowGroupPanel { get; set; }
}
