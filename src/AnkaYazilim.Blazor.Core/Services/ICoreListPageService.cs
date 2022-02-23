namespace AnkaYazilim.Blazor.Core.Services;

public interface ICoreListPageService
{
    public bool ToolbarCheckBoxVisible { get; set; }
    public bool IsActiveCards { get; set; }
    public string LoadingCaption { get; set; }
    public string LoadingText{ get; set; }
    public bool IsPopUpListPage { get; set; }
    public bool EditPageVisible { get; set; }




}
