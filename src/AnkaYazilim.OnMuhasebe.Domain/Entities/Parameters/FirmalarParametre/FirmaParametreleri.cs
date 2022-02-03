namespace AnkaYazilim.OnMuhasebe.Entities.Parameters.FirmalarParametre;

public class FirmaParametreleri:Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid SubeId { get; set; }
    public Guid DonemId { get; set; }
    public Guid? DepoId { get; set; }

}
