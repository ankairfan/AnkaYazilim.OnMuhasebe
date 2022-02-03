using System.Threading.Tasks;

namespace AnkaYazilim.OnMuhasebe.Data;

public interface IOnMuhasebeDbSchemaMigrator
{
    Task MigrateAsync();
}
