namespace AnkaYazilim.OnMuhasebe.EntityRepositories.BankaHesaplar;

public class EfCoreBankaHesapRepository : EfCoreCommonRepository<BankaHesap>, IBankaHesapRepository
{
    public EfCoreBankaHesapRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
