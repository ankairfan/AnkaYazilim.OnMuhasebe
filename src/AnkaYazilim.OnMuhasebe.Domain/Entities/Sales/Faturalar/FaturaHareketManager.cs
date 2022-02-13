namespace AnkaYazilim.OnMuhasebe.Entities.Sales.Faturalar;

public class FaturaHareketManager : DomainService
{
    private readonly IStokRepository _stokRepository;
    private readonly IHizmetRepository _hizmetRepository;
    private readonly IMasrafRepository _masrafRepository;
    private readonly IDepoRepository _depoRepository;

    public FaturaHareketManager(IDepoRepository depoRepository, IMasrafRepository masrafRepository, IHizmetRepository hizmetRepository, IStokRepository stokRepository)
    {
        _depoRepository = depoRepository;
        _masrafRepository = masrafRepository;
        _hizmetRepository = hizmetRepository;
        _stokRepository = stokRepository;
    }

    public async Task CheckCreateAsync(Guid? stokId, Guid? hizmetId, Guid? masrafId, Guid? depoId)
    {
        await _stokRepository.EntityAnyAsync(stokId, x => x.Id == stokId);
        await _hizmetRepository.EntityAnyAsync(hizmetId, x=>x.Id == hizmetId);
        await _masrafRepository.EntityAnyAsync(masrafId, x=>x.Id==masrafId);
        await _depoRepository.EntityAnyAsync(depoId, x=>x.Id == depoId);
    }

    public async Task CheckUpdateAsync(Guid? stokId, Guid? hizmetId, Guid? masrafId, Guid? depoId)
    {
        await _stokRepository.EntityAnyAsync(stokId, x => x.Id == stokId);
        await _hizmetRepository.EntityAnyAsync(hizmetId, x => x.Id == hizmetId);
        await _masrafRepository.EntityAnyAsync(masrafId, x => x.Id == masrafId);
        await _depoRepository.EntityAnyAsync(depoId, x => x.Id == depoId);
    }
}
