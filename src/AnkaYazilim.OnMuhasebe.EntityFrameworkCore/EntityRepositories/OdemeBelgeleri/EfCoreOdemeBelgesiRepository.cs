using AnkaYazilim.OnMuhasebe.Entities.OdemeBelgeleri;

namespace AnkaYazilim.OnMuhasebe.EntityRepositories.OdemeBelgeleri;

public class EfCoreOdemeBelgesiRepository:EfCoreCommonRepository<OdemeBelgesi>, IOdemeBelgesiRepository
{
    public EfCoreOdemeBelgesiRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    
}