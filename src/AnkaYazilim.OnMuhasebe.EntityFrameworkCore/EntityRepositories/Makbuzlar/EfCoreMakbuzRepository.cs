﻿namespace AnkaYazilim.OnMuhasebe.EntityRepositories.Makbuzlar;

public class EfCoreMakbuzRepository : EfCoreCommonRepository<Makbuz>, IMakbuzRepository
{
    public EfCoreMakbuzRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Makbuz>> WithDetailsAsync()
    {
        return (await GetQueryableAsync())
            .Include(x => x.Cari)
            .Include(x => x.Kasa)
            .Include(x => x.BankaHesap)
            .Include(x => x.OzelKod1)
            .Include(x => x.OzelKod2)
            .Include(x => x.MakbuzHareketleri).ThenInclude(x => x.CekBanka)
            .Include(x => x.MakbuzHareketleri).ThenInclude(x => x.CekBankaSube)
            .Include(x => x.MakbuzHareketleri).ThenInclude(x => x.Kasa)
            .Include(x => x.MakbuzHareketleri).ThenInclude(x => x.BankaHesap);
    }
}
