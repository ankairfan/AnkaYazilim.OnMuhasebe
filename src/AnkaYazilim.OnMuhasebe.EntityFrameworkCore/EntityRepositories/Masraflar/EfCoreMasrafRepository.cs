namespace AnkaYazilim.OnMuhasebe.EntityRepositories.Masraflar;

public class EfCoreMasrafRepository : EfCoreCommonRepository<Masraf>, IMasrafRepository
{
    public EfCoreMasrafRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    public override async Task<IQueryable<Masraf>> WithDetailsAsync()
    {
        return (await GetQueryableAsync())
            .Include(x => x.Birim)
            .Include(x => x.OzelKod1)
            .Include(x => x.OzelKod2)
            .Include(x => x.FaturaHareketleri).ThenInclude(x => x.Fatura);

    }
}
