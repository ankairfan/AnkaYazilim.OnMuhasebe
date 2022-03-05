using Volo.Abp.Application.Dtos;

namespace AnkaYazilim.Blazor.Core.Services;

public interface ICoreAppService
{
    public IEntityDto FirmaParametre { get; set; }
}
