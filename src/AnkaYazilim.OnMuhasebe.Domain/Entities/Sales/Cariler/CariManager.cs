namespace AnkaYazilim.OnMuhasebe.Entities.Sales.Cariler;

public class CariManager : DomainService
{
    private readonly ICariRepository _cariRepository;
    private readonly IOzelKodRepository _ozelKodRepository;

    public CariManager(IOzelKodRepository kodRepository, ICariRepository cariRepository)
    {
        _ozelKodRepository = kodRepository;
        _cariRepository = cariRepository;
    }
    public async Task CheckCreateAsync(string kod, Guid? ozelKod1Id, Guid? ozelKod2Id)
    {
        await _cariRepository.KodAnyAsync(kod, x => x.Kod == kod);
        await _ozelKodRepository.EntityAnyAsync(ozelKod1Id, OzelKodTuru.OzelKod1, KartTuru.Cari);
        await _ozelKodRepository.EntityAnyAsync(ozelKod2Id, OzelKodTuru.OzelKod2, KartTuru.Cari);
    }

    public async Task CheckUpdateAsync(Guid id, string kod, Cari entity, Guid? ozelKod1Id, Guid? ozelKod2Id)
    {
        await _cariRepository.KodAnyAsync(kod, x => x.Id != id && x.Kod == kod, entity.Kod != kod);
        await _ozelKodRepository.EntityAnyAsync(ozelKod1Id, OzelKodTuru.OzelKod1, KartTuru.Cari, entity.OzelKod1Id != ozelKod1Id);
        await _ozelKodRepository.EntityAnyAsync(ozelKod2Id, OzelKodTuru.OzelKod2, KartTuru.Cari, entity.OzelKod2Id != ozelKod2Id);
    }

    public async Task CheckDeleteAsync(Guid id)
    {
        await _cariRepository.RelationalEntityAnyAsync(
            x => x.Makbuzlar.Any(y => y.CariId == id) ||
            x.Faturalar.Any(y => y.CariId == id));
    }
}
