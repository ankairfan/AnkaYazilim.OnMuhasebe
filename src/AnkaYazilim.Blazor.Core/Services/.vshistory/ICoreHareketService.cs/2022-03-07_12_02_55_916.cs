namespace AnkaYazilim.Blazor.Core.Services;

public interface ICoreHareketeService<TDataGridItem> : ICoreDataGridService<TDataGridItem>, ICoreEditPageService<TDataGridItem>, ICoreListPageService,
    ICoreMessageService, ICoreCommonService
{

}
