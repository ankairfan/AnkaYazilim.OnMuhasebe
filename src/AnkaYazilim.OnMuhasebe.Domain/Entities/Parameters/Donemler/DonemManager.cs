namespace AnkaYazilim.OnMuhasebe.Entities.Parameters.Donemler;

public class DonemManager : DomainService
{
    private readonly IDonemRepository _repository;

    public DonemManager(IDonemRepository repository)
    {
        _repository = repository;
    }

    public async Task CheckCreateAsync(string kod)
    {
        await _repository.KodAnyAsync(kod, x => x.Kod == kod);
    }

    public async Task CheckUpdateAsync(Guid id, string kod, Donem entity)
    {
        await _repository.KodAnyAsync(kod, x => x.Id != id && x.Kod == kod && entity.Kod != kod);
    }

    public async Task CheckDeleteAsync(Guid id)
    {
        await _repository.RelationalEntityAnyAsync(
            x => x.Faturalar.Any(y => y.DonemId == id) || x.Makbuzlar.Any(y => y.DonemId == id));
    }
}
