namespace AnkaYazilim.OnMuhasebe.EntityRepositories.OzelKodlar;

public class EfCoreOzelKodRepository : EfCoreCommonRepository<OzelKod>, IOzelKodRepository
{
    public EfCoreOzelKodRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
