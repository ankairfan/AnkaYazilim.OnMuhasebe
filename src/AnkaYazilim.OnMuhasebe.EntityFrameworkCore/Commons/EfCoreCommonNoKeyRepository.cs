namespace AnkaYazilim.OnMuhasebe.Commons;

public class EfCoreCommonNoKeyRepository<TEntity> : EfCoreRepository<OnMuhasebeDbContext, TEntity>, ICommonNoKeyRepository<TEntity> where TEntity : class, IEntity
{
    public EfCoreCommonNoKeyRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<TEntity> FromSqlRawSingleAsync(string sql, params object[] parameters)
    {
        var dbSet= await GetDbSetAsync();
        return await dbSet.FromSqlRaw(sql,parameters).FirstOrDefaultAsync();
    }



    public async Task<IList<TEntity>> FromSqlRawAsync(string sql, params object[] parameters)
    {
        var dbSet=await GetDbSetAsync();
        return dbSet.FromSqlRaw(sql, parameters).ToList();
    }

  
}
