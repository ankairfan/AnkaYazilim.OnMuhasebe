namespace AnkaYazilim.Blazor.Core.Services;

public interface ICoreHareketService<TDataGridItem> : ICoreDataGridService<TDataGridItem>, ICoreEditPageService<TDataGridItem>, ICoreListPageService,
    ICoreMessageService, ICoreCommonService
{

}
