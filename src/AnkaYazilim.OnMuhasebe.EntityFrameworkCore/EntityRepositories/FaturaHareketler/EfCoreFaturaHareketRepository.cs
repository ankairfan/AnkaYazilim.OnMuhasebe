namespace AnkaYazilim.OnMuhasebe.EntityRepositories.FaturaHareketler;

public class EfCoreFaturaHareketRepository : EfCoreCommonRepository<FaturaHareket>, IFaturaHareketRepository
{
    public EfCoreFaturaHareketRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
