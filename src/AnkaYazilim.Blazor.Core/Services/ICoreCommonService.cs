using Microsoft.AspNetCore.Components;

namespace AnkaYazilim.Blazor.Core.Services;

public interface ICoreCommonService
{
    public Action HasChanged { get; set; }
    public ComponentBase ActiveEditComponent { get; set; }
      
}
