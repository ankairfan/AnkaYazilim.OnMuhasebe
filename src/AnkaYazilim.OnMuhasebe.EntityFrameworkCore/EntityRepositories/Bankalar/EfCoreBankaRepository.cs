namespace AnkaYazilim.OnMuhasebe.EntityRepositories.Bankalar;

public class EfCoreBankaRepository : EfCoreCommonRepository<Banka>, IBankaRepository
{
    public EfCoreBankaRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
