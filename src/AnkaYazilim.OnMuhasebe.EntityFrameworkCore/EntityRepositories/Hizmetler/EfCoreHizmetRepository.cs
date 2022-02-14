namespace AnkaYazilim.OnMuhasebe.EntityRepositories.Hizmetler;

public class EfCoreHizmetRepository : EfCoreCommonRepository<Hizmet>, IHizmetRepository
{
    public EfCoreHizmetRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Hizmet>> WithDetailsAsync()
    {
        return (await GetQueryableAsync())
            .Include(x => x.Birim)
            .Include(x => x.OzelKod1)
            .Include(x => x.OzelKod2)
            .Include(x => x.FaturaHareketleri).ThenInclude(x => x.Fatura);
            
    }
}
