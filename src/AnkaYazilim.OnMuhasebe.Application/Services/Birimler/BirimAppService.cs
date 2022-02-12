namespace AnkaYazilim.OnMuhasebe.Services.Birimler;

public class BirimAppService : OnMuhasebeAppService, IBirimAppService
{
    private readonly IBirimRepository _repository;
    private readonly BirimManager _birimManager;

    public BirimAppService(IBirimRepository repository, BirimManager birimManager)
    {
        _repository = repository;
        _birimManager = birimManager;
    }


    public virtual async Task<SelectBirimDto> GetAsync(Guid id)
    {
        var entity = await _repository.GetAsync(id, x => x.Id == id, x => x.OzelKod1, x => x.OzelKod2);
        return ObjectMapper.Map<Birim, SelectBirimDto>(entity);
    }

    public virtual async Task<PagedResultDto<ListBirimDto>> GetListAsync(BirimListParameterDto input)
    {
        var entities = await _repository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, x => x.Durum == input.Durum, x => x.Kod, x => x.OzelKod1, x => x.OzelKod2);
        var totalCount = await _repository.CountAsync(x => x.Durum == input.Durum);
        return new PagedResultDto<ListBirimDto>(totalCount, ObjectMapper.Map<List<Birim>, List<ListBirimDto>>(entities));
    }

    public virtual async Task<SelectBirimDto> CreateAsync(CreateBirimDto input)
    {
        await _birimManager.CheckCreateAsync(input.Kod, input.OzelKod1Id, input.OzelKod2Id);
        var entity = ObjectMapper.Map<CreateBirimDto, Birim>(input);
        await _repository.InsertAsync(entity);
        return ObjectMapper.Map<Birim, SelectBirimDto>(entity);
    }


    public virtual async Task<SelectBirimDto> UpdateAsync(Guid id, UpdateBirimDto input)
    {
        var entity = await _repository.GetAsync(id, x => x.Id == id);
        await _birimManager.CheckUpdateAsync(id, input.Kod, entity, input.OzelKod1Id, input.OzelKod2Id);
        var mappedEntity = ObjectMapper.Map(input, entity);
        await _repository.UpdateAsync(mappedEntity);
        return ObjectMapper.Map<Birim, SelectBirimDto>(mappedEntity);
    }


    public virtual async Task DeleteAsync(Guid id)
    {
        await _birimManager.CheckDeleteAsync(id);
        await _repository.DeleteAsync(id);
    }



    public virtual async Task<string> GetCodeAsync(CodeParameterDto input)
    {
        return await _repository.GetCodeAsync(x => x.Kod, x => x.Durum == input.Durum);
    }

}
