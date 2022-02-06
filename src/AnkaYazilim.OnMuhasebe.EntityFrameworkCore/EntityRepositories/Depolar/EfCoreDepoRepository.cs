namespace AnkaYazilim.OnMuhasebe.EntityRepositories.Depolar;

public class EfCoreDepoRepository : EfCoreCommonRepository<Depo>, IDepoRepository
{
    public EfCoreDepoRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
