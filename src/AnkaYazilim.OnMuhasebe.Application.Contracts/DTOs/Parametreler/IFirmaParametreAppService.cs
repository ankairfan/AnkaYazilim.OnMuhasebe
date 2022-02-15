namespace AnkaYazilim.OnMuhasebe.DTOs.Parametreler;

public interface IFirmaParametreAppService : AnkaYazilim.OnMuhasebe.Services.ICrudAppService<SelectFirmaParametreDto, SelectFirmaParametreDto, FirmaParametreListParameterDto, CreateFirmaParametreDto, UpdateFirmaParametreDto>
{
    Task<bool> UserAnyAsync(Guid userId);
}
