using Volo.Abp.Application.Dtos;

namespace AnkaYazilim.Blazor.Core.Services;

public interface ICoreEditPageService<TDataSource>
{
    public TDataSource DataSource { get; set; }
    void ButtonEditDeleteKeyDown(IEntityDto entity, string fieldName);
}
