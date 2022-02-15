namespace AnkaYazilim.OnMuhasebe.Entities.Finance.Makbuzlar;

public class MakbuzHareketManager : DomainService
{
    private readonly IBankaRepository _bankaRepository;
    private readonly IBankaSubeRepository _subeRepository;
    private readonly IKasaRepository _kasaRepository;
    private readonly IBankaHesapRepository _bankaHesapRepository;

    public MakbuzHareketManager(IBankaRepository bankaRepository, IBankaSubeRepository subeRepository, IKasaRepository kasaRepository, IBankaHesapRepository bankaHesapRepository)
    {
        _bankaRepository = bankaRepository;
        _subeRepository = subeRepository;
        _kasaRepository = kasaRepository;
        _bankaHesapRepository = bankaHesapRepository;
    }

    public async Task CheckCreateAsync(Guid? cekBankaId, Guid? cekBankaSubeId, Guid? kasaId, Guid? bankaHesapId)
    {
        await _bankaRepository.EntityAnyAsync(cekBankaId, x => x.Id == cekBankaId);
        await _subeRepository.EntityAnyAsync(cekBankaSubeId, x=>x.Id == cekBankaSubeId);
        await _kasaRepository.EntityAnyAsync(kasaId, x=>x.Id == kasaId);
        await _bankaHesapRepository.EntityAnyAsync(bankaHesapId, x => x.Id == bankaHesapId);
    }

    public async Task CheckUpdateAsync(Guid? cekBankaId, Guid? cekBankaSubeId, Guid? kasaId, Guid? bankaHesapId)
    {
        await _bankaRepository.EntityAnyAsync(cekBankaId, x => x.Id == cekBankaId);
        await _subeRepository.EntityAnyAsync(cekBankaSubeId, x => x.Id == cekBankaSubeId);
        await _kasaRepository.EntityAnyAsync(kasaId, x => x.Id == kasaId);
        await _bankaHesapRepository.EntityAnyAsync(bankaHesapId, x => x.Id == bankaHesapId);
    }
}
