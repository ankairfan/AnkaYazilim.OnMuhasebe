namespace AnkaYazilim.OnMuhasebe.EntityRepositories.Kasalar;

public class EfCoreKasaRepository : EfCoreCommonRepository<Kasa>, IKasaRepository
{
    public EfCoreKasaRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
