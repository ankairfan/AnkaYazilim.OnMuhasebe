namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class AppService : ICoreAppService, IScopedDependency
{
    public SelectFirmaParametreDto FirmaParametre { get; set; } = new SelectFirmaParametreDto
    {
        SubeId = new Guid("285b30a0-6972-1061-2e0b-3a025b794e00"),
        DonemId = new Guid("468ecf35-4354-b81e-548b-3a025b78ee99")
    };
    public Action HasChanged { get; set; }
    public bool ShowFirmaParametreEditPage { get; set; }
    public bool ShowSubeDonemEditPage { get; set; }
}

