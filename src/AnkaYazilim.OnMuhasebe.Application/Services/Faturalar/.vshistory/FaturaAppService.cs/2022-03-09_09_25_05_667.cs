namespace AnkaYazilim.OnMuhasebe.Services.Faturalar;

public class FaturaAppService : OnMuhasebeAppService, IFaturaAppService
{
    private readonly IFaturaRepository _repository;
    private readonly FaturaManager _faturaManager;
    private readonly FaturaHareketManager _hareketManager;

    public FaturaAppService(IFaturaRepository repository, FaturaManager faturaManager, FaturaHareketManager hareketManager)
    {
        _repository = repository;
        _faturaManager = faturaManager;
        _hareketManager = hareketManager;
    }

    public virtual async Task<SelectFaturaDto> GetAsync(Guid id)
    {
        var entity = await _repository.GetAsync(id, x => x.Id == id);

        var mappedDto = ObjectMapper.Map<Fatura, SelectFaturaDto>(entity);
        mappedDto.FaturaHareketler.ForEach(x =>
        {
            x.HareketTuruAdi = L[$"Enum:FaturaHareketTuru:{(byte)x.HareketTuru}"];
        });

        return mappedDto;
    }

    public virtual async Task<PagedResultDto<ListFaturaDto>> GetListAsync(FaturaListParameterDto input)
    {
        var entities = await _repository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, x => x.FaturaTuru == input.FaturaTuru &&
        x.SubeId == input.SubeId && x.DonemId == input.DonemId && x.Durum == input.Durum, x => x.FaturaNo, x => x.Cari, x => x.OzelKod1, x => x.OzelKod2);

        var totalCount = await _repository.CountAsync(x => x.FaturaTuru == input.FaturaTuru &&
         x.SubeId == input.SubeId && x.DonemId == input.DonemId && x.Durum == input.Durum);

        return new PagedResultDto<ListFaturaDto>(totalCount, ObjectMapper.Map<List<Fatura>, List<ListFaturaDto>>(entities));
    }

    public virtual async Task<SelectFaturaDto> CreateAsync(CreateFaturaDto input)
    {
        await _faturaManager.CheckCreateAsync(input.FaturaNo, input.CariId, input.OzelKod1Id,
      input.OzelKod2Id, input.SubeId, input.DonemId);

        foreach (var faturaHareket in input.FaturaHareketler)
        {
            await _hareketManager.CheckCreateAsync(faturaHareket.StokId,
                faturaHareket.HizmetId, faturaHareket.MasrafId, faturaHareket.DepoId);
        }

        var entity = ObjectMapper.Map<CreateFaturaDto, Fatura>(input);
        await _repository.InsertAsync(entity);
        return ObjectMapper.Map<Fatura, SelectFaturaDto>(entity);
    }

    public virtual async Task<SelectFaturaDto> UpdateAsync(Guid id, UpdateFaturaDto input)
    {
        var entity = await _repository.GetAsync(id, x => x.Id == id,
    x => x.FaturaHareketleri);

        await _faturaManager.CheckUpdateAsync(id, input.FaturaNo, entity, input.CariId,
            input.OzelKod1Id, input.OzelKod2Id);

        foreach (var faturaHareketDto in input.FaturaHareketler)
        {
            await _hareketManager.CheckUpdateAsync(faturaHareketDto.StokId,
                faturaHareketDto.HizmetId, faturaHareketDto.MasrafId, faturaHareketDto.DepoId);

            var faturaHareket = entity.FaturaHareketleri.FirstOrDefault(
                x => x.Id == faturaHareketDto.Id);

            if (faturaHareket == null)
            {
                entity.FaturaHareketleri.Add(
                    ObjectMapper.Map<FaturaHareketDto, FaturaHareket>(faturaHareketDto));
                continue;
            }

            ObjectMapper.Map(faturaHareketDto, faturaHareket);
        }

        var deletedEntities = entity.FaturaHareketleri.Where(
            x => input.FaturaHareketler.Select(y => y.Id).ToList().IndexOf(x.Id) == -1);

        entity.FaturaHareketleri.RemoveAll(deletedEntities);

        ObjectMapper.Map(input, entity);
        await _repository.UpdateAsync(entity);
        return ObjectMapper.Map<Fatura, SelectFaturaDto>(entity);
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await _repository.GetAsync(id, x => x.Id == id, x => x.FaturaHareketleri);
        await _repository.DeleteAsync(entity);
        entity.FaturaHareketleri.RemoveAll(entity.FaturaHareketleri);
    }

    public virtual Task<string> GetCodeAsync(FaturaNoParameterDto input)
    {
        return _repository.GetCodeAsync(x => x.FaturaNo, x => x.FaturaTuru == input.FaturaTuru && x.SubeId == input.SubeId && x.DonemId == input.DonemId && x.Durum == input.Durum);
    }
}