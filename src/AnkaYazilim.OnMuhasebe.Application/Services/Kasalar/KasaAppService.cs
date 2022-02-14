namespace AnkaYazilim.OnMuhasebe.Services.Kasalar;

public class KasaAppService : OnMuhasebeAppService, IKasaAppService
{
    private readonly IKasaRepository _repositoy;
    private readonly KasaManager _manager;

    public KasaAppService(IKasaRepository repositoy, KasaManager manager)
    {
        _repositoy = repositoy;
        _manager = manager;
    }

    public virtual async Task<SelectKasaDto> GetAsync(Guid id)
    {
        var entity = await _repositoy.GetAsync(id, x => x.Id == id, x => x.OzelKod1, x => x.OzelKod2);
        return ObjectMapper.Map<Kasa, SelectKasaDto>(entity);
    }

    public virtual async Task<PagedResultDto<ListKasaDto>> GetListAsync(KasaListParameterDto input)
    {
        var entities = await _repositoy.GetPagedListAsync(input.SkipCount, input.MaxResultCount, x => x.SubeId ==
        input.SubeId && x.Durum == input.Durum, x => x.Kod, x => x.OzelKod1, x => x.OzelKod2, x => x.MakbuzHareketleri);

        var totalCount = await _repositoy.CountAsync(x => x.SubeId == input.SubeId && x.Durum == input.Durum);

        return new PagedResultDto<ListKasaDto>(totalCount, ObjectMapper.Map<List<Kasa>, List<ListKasaDto>>(entities));

    }

    public virtual async Task<SelectKasaDto> CreateAsync(CreateKasaDto input)
    {
        await _manager.CheckCreateAsync(input.Kod, input.OzelKod1Id, input.OzelKod2Id, input.SubeId);
        var entity = ObjectMapper.Map<CreateKasaDto, Kasa>(input);
        await _repositoy.InsertAsync(entity);
        return ObjectMapper.Map<Kasa, SelectKasaDto>(entity);
    }
    public virtual async Task<SelectKasaDto> UpdateAsync(Guid id, UpdateKasaDto input)
    {
        var entity = await _repositoy.GetAsync(id, x => x.Id == id);
        await _manager.CheckUpdateAsync(id, input.Kod, entity, input.OzelKod1Id, input.OzelKod2Id);
        var mappedEntity = ObjectMapper.Map(input, entity);
        await _repositoy.UpdateAsync(mappedEntity);
        return ObjectMapper.Map<Kasa, SelectKasaDto>(mappedEntity);
    }
    public virtual async Task DeleteAsync(Guid id)
    {
        await _manager.CheckDeleteAsync(id);
        await _repositoy.DeleteAsync(id);
    }
    public virtual async Task<string> GetCodeAsync(KasaCodeParameterDto input)
    {
        return await _repositoy.GetCodeAsync(x => x.Kod, x => x.SubeId == input.SubeId && x.Durum == input.Durum);
    }

}
