namespace AnkaYazilim.OnMuhasebe.EntityRepositories.Stoklar;

public class EfCoreStokRepository : EfCoreCommonRepository<Stok>, IStokRepository
{
    public EfCoreStokRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
