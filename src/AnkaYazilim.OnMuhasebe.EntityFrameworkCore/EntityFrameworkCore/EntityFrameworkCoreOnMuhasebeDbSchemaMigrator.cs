using AnkaYazilim.OnMuhasebe.Data;
using Microsoft.Extensions.DependencyInjection;

namespace AnkaYazilim.OnMuhasebe.EntityFrameworkCore;

public class EntityFrameworkCoreOnMuhasebeDbSchemaMigrator
    : IOnMuhasebeDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreOnMuhasebeDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task MigrateAsync()
    {
        /* We intentionally resolving the OnMuhasebeDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        return _serviceProvider
            .GetRequiredService<OnMuhasebeDbContext>()
            .Database
            .MigrateAsync();
    }
}