namespace AnkaYazilim.OnMuhasebe.Services.BankaSubeler;

public class BankaSubeAppService : OnMuhasebeAppService, IBankaSubeAppService
{
    private readonly IBankaSubeRepository _repository;
    private readonly BankaSubeManager _manager;

    public BankaSubeAppService(IBankaSubeRepository repository, BankaSubeManager manager)
    {
        _repository = repository;
        _manager = manager;
    }

    public virtual async Task<SelectBankaSubeDto> GetAsync(Guid id)
    {
        var entity = await _repository.GetAsync(id, b => b.Id == id, x => x.Banka, x => x.OzelKod1, x => x.OzelKod2);
        return ObjectMapper.Map<BankaSube, SelectBankaSubeDto>(entity);
    }

    public virtual async Task<PagedResultDto<ListBankaSubeDto>> GetListAsync(BankaSubeListParameterDto input)
    {
        var entities = await _repository.GetPagedLastListAsync(input.SkipCount, input.MaxResultCount, x => x.BankaId == input.BankaId && x.Durum == input.Durum, x => x.Kod, x => x.Banka, x => x.OzelKod1, x => x.OzelKod2);
        var totalCount = await _repository.CountAsync(x => x.BankaId == input.BankaId && x.Durum == input.Durum);
        return new PagedResultDto<ListBankaSubeDto>(totalCount, ObjectMapper.Map<List<BankaSube>, List<ListBankaSubeDto>>(entities));
    }

    public virtual async Task<SelectBankaSubeDto> CreateAsync(CreateBankaSubeDto input)
    {
        await _manager.CheckCreateAsync(input.Kod, input.BankaId, input.OzelKod1Id, input.OzelKod2Id);
        var entity = ObjectMapper.Map<CreateBankaSubeDto, BankaSube>(input);
        await _repository.InsertAsync(entity);
        return ObjectMapper.Map<BankaSube, SelectBankaSubeDto>(entity);
    }


    public virtual async Task<SelectBankaSubeDto> UpdateAsync(Guid id, UpdateBankaSubeDto input)
    {
        var entity = await _repository.GetAsync(id, x => x.Id == id);
        await _manager.CheckUpdateAsync(id, input.Kod, entity, input.OzelKod1Id, input.OzelKod1Id);
        var mappedEntity = ObjectMapper.Map(input, entity);
        await _repository.UpdateAsync(mappedEntity);
        return ObjectMapper.Map<BankaSube, SelectBankaSubeDto>(mappedEntity);

    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await _manager.CheckDeleteAsync(id);
        await _repository.DeleteAsync(id);
    }

    public virtual async Task<string> GetCodeAsync(BankaSubeCodeParametreDto input)
    {
        return await _repository.GetCodeAsync(x => x.Kod, x => x.BankaId == input.BankaId && x.Durum == input.Durum);
    }




}
