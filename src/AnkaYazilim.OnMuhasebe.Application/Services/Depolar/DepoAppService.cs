namespace AnkaYazilim.OnMuhasebe.Services.Depolar;

public class DepoAppService : OnMuhasebeAppService, IDepoAppService
{
    private readonly IDepoRepository _repository;
    private readonly DepoManager _manager;

    public DepoAppService(IDepoRepository repository, DepoManager manager)
    {
        _repository = repository;
        _manager = manager;
    }

    public virtual async Task<SelectDepoDto> GetAsync(Guid id)
    {
        var entity = await _repository.GetAsync(id, x => x.Id == id, x => x.OzelKod1, x => x.OzelKod2);
        return ObjectMapper.Map<Depo, SelectDepoDto>(entity);
    }

    public virtual async Task<PagedResultDto<ListDepoDto>> GetListAsync(DepoListParameterDto input)
    {
        var entities = await _repository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, x => x.SubeId == input.SubeId && x.Durum == input.Durum, x => x.Kod);
        var totalCount = await _repository.CountAsync(x => x.SubeId == input.SubeId && x.Durum == input.Durum);
        var mappedDtos = ObjectMapper.Map<List<Depo>, List<ListDepoDto>>(entities);
        mappedDtos.ForEach(x =>
        {
            x.Giren = x.FaturaHareketler.Where(y => y.Fatura.FaturaTuru == FaturaTuru.Alis).Sum(y => y.Miktar);
            x.Cikan = x.FaturaHareketler.Where(y => y.Fatura.FaturaTuru == FaturaTuru.satis).Sum(y => y.Miktar);
        });

        return new PagedResultDto<ListDepoDto>(totalCount, mappedDtos);
    }

    public virtual async Task<SelectDepoDto> CreateAsync(CreateDepoDto input)
    {
        await _manager.CheckCreateAsync(input.Kod, input.OzelKod1Id, input.OzelKod2Id, input.SubeId);
        var entity = ObjectMapper.Map<CreateDepoDto, Depo>(input);
        await _repository.InsertAsync(entity);
        return ObjectMapper.Map<Depo, SelectDepoDto>(entity);
    }


    public virtual async Task<SelectDepoDto> UpdateAsync(Guid id, UpdateDepoDto input)
    {
        var entity = await _repository.GetAsync(id, x => x.Id == id);
        await _manager.CheckUpdateAsync(id, input.Kod, entity, input.OzelKod1Id, input.OzelKod2Id);
        var mappedEntity = ObjectMapper.Map(input, entity);
        await _repository.UpdateAsync(mappedEntity);
        return ObjectMapper.Map<Depo, SelectDepoDto>(mappedEntity);
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await _manager.CheckDeleteAsync(id);
        await _repository.DeleteAsync(id);
    }

    public virtual async Task<string> GetCodeAsync(DepoCodeParameterDto input)
    {
        return await _repository.GetCodeAsync(x => x.Kod, x => x.SubeId == input.SubeId && x.Durum == input.Durum);
    }
}
