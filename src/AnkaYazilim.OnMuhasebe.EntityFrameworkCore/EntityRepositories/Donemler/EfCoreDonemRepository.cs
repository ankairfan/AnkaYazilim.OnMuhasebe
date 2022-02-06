namespace AnkaYazilim.OnMuhasebe.EntityRepositories.Donemler;

public class EfCoreDonemRepository : EfCoreCommonRepository<Donem>, IDonemRepository
{
    public EfCoreDonemRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
