namespace AnkaYazilim.OnMuhasebe.EntityRepositories.MakbuzHareketler;

public class EfCoreMakbuzHareketRepository : EfCoreCommonRepository<MakbuzHareket>, IMakbuzHareketRepository
{
    public EfCoreMakbuzHareketRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
