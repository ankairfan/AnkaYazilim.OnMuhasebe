namespace AnkaYazilim.OnMuhasebe.Entities.Masraflar;

public class MasrafManager : DomainService
{
    private readonly IMasrafRepository _masrafRepository;
    private readonly IOzelKodRepository _ozelKodRepository;
    private readonly IBirimRepository _birimRepository;

    public MasrafManager(IMasrafRepository masrafRepository, IOzelKodRepository ozelKodRepository, IBirimRepository birimRepository)
    {
        _masrafRepository = masrafRepository;
        _ozelKodRepository = ozelKodRepository;
        _birimRepository = birimRepository;
    }

    public async Task CheckCreateAsync(string kod, Guid? birimId, Guid? ozelKod1Id, Guid? ozelKod2Id)
    {
        await _masrafRepository.KodAnyAsync(kod, x => x.Kod == kod);
        await _birimRepository.EntityAnyAsync(birimId, x => x.Id == birimId);
        await _ozelKodRepository.EntityAnyAsync(ozelKod1Id, OzelKodTuru.OzelKod1, KartTuru.Masraf);
        await _ozelKodRepository.EntityAnyAsync(ozelKod2Id, OzelKodTuru.OzelKod2, KartTuru.Masraf);
    }

    public async Task CheckUpdateAsync(Guid id, string kod, Masraf entity, Guid? birimId, Guid? ozelKod1Id, Guid? ozelKod2Id)
    {
        await _masrafRepository.KodAnyAsync(kod, x => x.Id != id && x.Kod == kod, entity.Kod != kod);
        await _birimRepository.EntityAnyAsync(birimId, x => x.Id == birimId);
        await _ozelKodRepository.EntityAnyAsync(ozelKod1Id, OzelKodTuru.OzelKod1, KartTuru.Masraf, entity.OzelKod1Id != ozelKod1Id);
        await _ozelKodRepository.EntityAnyAsync(ozelKod2Id, OzelKodTuru.OzelKod2, KartTuru.Masraf, entity.OzelKod2Id != ozelKod2Id);
    }

    public Task CheckDeleteAsync(Guid id)
    {
        return _masrafRepository.RelationalEntityAnyAsync(x => x.FaturaHareketleri.Any(y => y.MasrafId == id));
    }
}