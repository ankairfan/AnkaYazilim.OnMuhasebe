namespace AnkaYazilim.OnMuhasebe.EntityRepositories.Hizmetler;

public class EfCoreHizmetRepository : EfCoreCommonRepository<Hizmet>, IHizmetRepository
{
    public EfCoreHizmetRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
