namespace AnkaYazilim.OnMuhasebe.Services.Donemler;

public class DonemAppService : OnMuhasebeAppService, IDonemAppService
{
    private readonly IDonemRepository _repository;
    private readonly DonemManager _manager;

    public DonemAppService(IDonemRepository repository, DonemManager manager)
    {
        _repository = repository;
        _manager = manager;
    }

    public virtual async Task<SelectDonemDto> GetAsync(Guid id)
    {
        var entity = await _repository.GetAsync(id, x => x.Id == id);
        return ObjectMapper.Map<Donem, SelectDonemDto>(entity);
    }

    public virtual async Task<PagedResultDto<ListDonemDto>> GetListAsync(DonemListParameterDto input)
    {
        var entities = await _repository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, x => x.Durum == input.Durum, x => x.Kod);
        var totalCount = await _repository.CountAsync(x => x.Durum == input.Durum);
        return new PagedResultDto<ListDonemDto>(totalCount, ObjectMapper.Map<List<Donem>, List<ListDonemDto>>(entities));
    }

    public virtual async Task<SelectDonemDto> CreateAsync(CreateDonemDto input)
    {
        await _manager.CheckCreateAsync(input.Kod);
        var entity = ObjectMapper.Map<CreateDonemDto, Donem>(input);
        await _repository.InsertAsync(entity);
        return ObjectMapper.Map<Donem, SelectDonemDto>(entity);
    }


    public virtual async Task<SelectDonemDto> UpdateAsync(Guid id, UpdateDonemDto input)
    {
        var entity = await _repository.GetAsync(id, x => x.Id == id);
        await _manager.CheckUpdateAsync(id, input.Kod, entity);
        var mappedEntity = ObjectMapper.Map(input, entity);
        await _repository.UpdateAsync(mappedEntity);
        return ObjectMapper.Map<Donem, SelectDonemDto>(mappedEntity);
    }


    public virtual async Task DeleteAsync(Guid id)
    {
        await _manager.CheckDeleteAsync(id);
        await _repository.DeleteAsync(id);
    }


    public virtual async Task<string> GetCodeAsync(CodeParameterDto input)
    {
        return await _repository.GetCodeAsync(x => x.Kod, x => x.Durum == input.Durum);
    }
}
