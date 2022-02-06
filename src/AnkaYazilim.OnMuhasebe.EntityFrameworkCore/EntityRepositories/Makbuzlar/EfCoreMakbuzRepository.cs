namespace AnkaYazilim.OnMuhasebe.EntityRepositories.Makbuzlar;

public class EfCoreMakbuzRepository : EfCoreCommonRepository<Makbuz>, IMakbuzRepository
{
    public EfCoreMakbuzRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
