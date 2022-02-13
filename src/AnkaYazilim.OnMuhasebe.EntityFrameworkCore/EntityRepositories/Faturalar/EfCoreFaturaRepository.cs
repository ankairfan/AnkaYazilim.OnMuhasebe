namespace AnkaYazilim.OnMuhasebe.EntityRepositories.Faturalar;

public class EfCoreFaturaRepository : EfCoreCommonRepository<Fatura>, IFaturaRepository
{
    public EfCoreFaturaRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Fatura>> WithDetailsAsync()
    {
        return (await GetQueryableAsync())
            .Include(x => x.Cari)
            .Include(x => x.OzelKod1)
            .Include(x => x.OzelKod2)
            .Include(x => x.FaturaHareketleri).ThenInclude(x=>x.Depo)
            .Include(x => x.FaturaHareketleri).ThenInclude(x => x.Stok).ThenInclude(x => x.Birim)
            .Include(x => x.FaturaHareketleri).ThenInclude(x => x.Hizmet).ThenInclude(x => x.Birim)
            .Include(x => x.FaturaHareketleri).ThenInclude(x => x.Masraf).ThenInclude(x => x.Birim);
    }
}
