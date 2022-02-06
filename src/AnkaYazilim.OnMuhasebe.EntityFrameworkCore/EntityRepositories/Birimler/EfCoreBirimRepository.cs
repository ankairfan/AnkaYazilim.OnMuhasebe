namespace AnkaYazilim.OnMuhasebe.EntityRepositories.Birimler;

public class EfCoreBirimRepository : EfCoreCommonRepository<Birim>, IBirimRepository
{
    public EfCoreBirimRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
