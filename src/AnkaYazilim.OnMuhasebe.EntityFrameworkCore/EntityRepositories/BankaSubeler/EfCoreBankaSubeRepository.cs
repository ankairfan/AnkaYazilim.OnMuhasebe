namespace AnkaYazilim.OnMuhasebe.EntityRepositories.BankaSubeler;

public class EfCoreBankaSubeRepository : EfCoreCommonRepository<BankaSube>, IBankaSubeRepository
{
    public EfCoreBankaSubeRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
