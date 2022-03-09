namespace AnkaYazilim.OnMuhasebe.Services.Hizmetler;

public class HizmetAppService : OnMuhasebeAppService, IHizmetAppService
{
    private readonly IHizmetRepository _repository;
    private readonly HizmetManager _manager;

    public HizmetAppService(IHizmetRepository repository, HizmetManager manager)
    {
        _repository = repository;
        _manager = manager;
    }

    public virtual async Task<SelectHizmetDto> GetAsync(Guid id)
    {
        var entity = await _repository.GetAsync(id, x => x.Id == id, x => x.Birim, x => x.OzelKod1, x => x.OzelKod2);
        return ObjectMapper.Map<Hizmet, SelectHizmetDto>(entity);
    }

    public virtual async Task<PagedResultDto<ListHizmetDto>> GetListAsync(HizmetListParameterDto input)
    {
        var entities = await _repository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, x => x.Durum == input.Durum, x => x.Kod);
        var totalCount = await _repository.CountAsync(x => x.Durum == input.Durum);
        return new PagedResultDto<ListHizmetDto>(totalCount, ObjectMapper.Map<List<Hizmet>, List<ListHizmetDto>>(entities));
    }

    public virtual async Task<SelectHizmetDto> CreateAsync(CreateHizmetDto input)
    {
        await _manager.CheckCreateAsync(input.Kod, input.BirimId, input.OzelKod1Id, input.OzelKod2Id);
        var entity = ObjectMapper.Map<CreateHizmetDto, Hizmet>(input);
        await _repository.InsertAsync(entity);
        return ObjectMapper.Map<Hizmet, SelectHizmetDto>(entity);
    }

    public virtual async Task<SelectHizmetDto> UpdateAsync(Guid id, UpdateHizmetDto input)
    {
        var entity = await _repository.GetAsync(id, x => x.Id == id);
        await _manager.CheckUpdateAsync(id, input.Kod, entity, input.BirimId, input.OzelKod1Id, input.OzelKod2Id);
        var mappedEntity = ObjectMapper.Map(input, entity);
        await _repository.UpdateAsync(mappedEntity);
        return ObjectMapper.Map<Hizmet, SelectHizmetDto>(mappedEntity);
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await _manager.CheckDeleteAsync(id);
        await _repository.DeleteAsync(id);
    }

    public virtual Task<string> GetCodeAsync(CodeParameterDto input)
    {
        return _repository.GetCodeAsync(x => x.Kod, x => x.Durum == input.Durum);
    }
}