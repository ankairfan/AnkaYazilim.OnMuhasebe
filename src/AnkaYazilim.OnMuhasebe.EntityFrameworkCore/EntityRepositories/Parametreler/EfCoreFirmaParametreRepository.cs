namespace AnkaYazilim.OnMuhasebe.EntityRepositories.Parametreler;

public class EfCoreFirmaParametreRepository : EfCoreCommonRepository<FirmaParametre>, IFirmaParametreRepository
{
    public EfCoreFirmaParametreRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
