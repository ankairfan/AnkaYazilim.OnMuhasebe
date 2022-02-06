namespace AnkaYazilim.OnMuhasebe.EntityRepositories.Cariler;

public class EfCoreCariRepository : EfCoreCommonRepository<Cari>, ICariRepository
{
    public EfCoreCariRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
