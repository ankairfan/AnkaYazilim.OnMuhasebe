namespace AnkaYazilim.OnMuhasebe.EntityRepositories.Depolar;

public class EfCoreDepoRepository : EfCoreCommonRepository<Depo>, IDepoRepository
{
    public EfCoreDepoRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    public async override Task<IQueryable<Depo>> WithDetailsAsync()
    {
        return (await GetQueryableAsync())
            .Include(x => x.OzelKod1)
            .Include(x => x.OzelKod2)
            .Include(x => x.FaturaHareketleri).ThenInclude(x => x.Fatura);
    }
}
