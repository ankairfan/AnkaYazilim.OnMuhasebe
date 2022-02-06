namespace AnkaYazilim.OnMuhasebe.EntityRepositories.Faturalar;

public class EfCoreFaturaRepository : EfCoreCommonRepository<Fatura>, IFaturaRepository
{
    public EfCoreFaturaRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
