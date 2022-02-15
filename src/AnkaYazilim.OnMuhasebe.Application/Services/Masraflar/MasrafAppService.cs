namespace AnkaYazilim.OnMuhasebe.Services.Masraflar;

public class MasrafAppService : OnMuhasebeAppService, IMasrafAppService
{
    private readonly IMasrafRepository _masrafRepository;
    private readonly MasrafManager _masrafManager;

    public MasrafAppService(IMasrafRepository masrafRepository, MasrafManager masrafManager)
    {
        _masrafRepository = masrafRepository;
        _masrafManager = masrafManager;
    }

    public virtual async Task<SelectMasrafDto> GetAsync(Guid id)
    {
        var entity = await _masrafRepository.GetAsync(id, x => x.Id == id, x => x.Birim, x => x.OzelKod1, x => x.OzelKod2);
        return ObjectMapper.Map<Masraf, SelectMasrafDto>(entity);
    }

    public virtual async Task<PagedResultDto<ListMasrafDto>> GetListAsync(MasrafListParameterDto input)
    {
        var entities = await _masrafRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, x => x.Durum == input.Durum, x => x.Kod);
        var totalCount = await _masrafRepository.CountAsync(x => x.Durum == input.Durum);
        return new PagedResultDto<ListMasrafDto>(totalCount, ObjectMapper.Map<List<Masraf>, List<ListMasrafDto>>(entities));
    }

    public virtual async Task<SelectMasrafDto> CreateAsync(CreateMasrafDto input)
    {
        await _masrafManager.CheckCreateAsync(input.Kod, input.BirimId, input.OzelKod1Id, input.OzelKod2Id);
        var entity = ObjectMapper.Map<CreateMasrafDto, Masraf>(input);
        await _masrafRepository.InsertAsync(entity);
        return ObjectMapper.Map<Masraf, SelectMasrafDto>(entity);
    }

    public virtual async Task<SelectMasrafDto> UpdateAsync(Guid id, UpdateMasrafDto input)
    {
        var entity = await _masrafRepository.GetAsync(id, x => x.Id == id);
        await _masrafManager.CheckUpdateAsync(id, input.Kod, entity, input.BirimId, input.OzelKod1Id, input.OzelKod2Id);
        var mappedEntity = ObjectMapper.Map(input, entity);
        await _masrafRepository.UpdateAsync(mappedEntity);
        return ObjectMapper.Map<Masraf, SelectMasrafDto>(mappedEntity);
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await _masrafManager.CheckDeleteAsync(id);
        await _masrafRepository.DeleteAsync(id);
    }

    public virtual async Task<string> GetCodeAsync(CodeParameterDto input)
    {
        return await _masrafRepository.GetCodeAsync(x => x.Kod, x => x.Durum == input.Durum);
    }

}
