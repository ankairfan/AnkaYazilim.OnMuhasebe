﻿using Volo.Abp.Domain.Repositories;

namespace AnkaYazilim.OnMuhasebe.Services.Bankalar;

public class BankaAppService : OnMuhasebeAppService, IBankaAppService
{
    private readonly IBankaRepository _repository;

    public BankaAppService(IBankaRepository repository)
    {
        _repository = repository;
    }

    public virtual async Task<SelectBankaDto> CreateAsync(CreateBankaDto input)
    {
        var entity = ObjectMapper.Map<CreateBankaDto, Banka>(input);
        await _repository.InsertAsync(entity);
        return ObjectMapper.Map<Banka, SelectBankaDto>(entity);
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public virtual async Task<SelectBankaDto> GetAsync(Guid id)
    {
        var entity = await _repository.GetAsync(id, b => b.Id == id, b=>b.OzelKod1, b=>b.OzelKod2);
        return ObjectMapper.Map<Banka, SelectBankaDto>(entity);
    }

    public virtual async Task<string> GetCodeAsync(CodeParameterDto input)
    {
        return await _repository.GetCodeAsync(b => b.Kod, b => b.Durum == input.Durum);
    }

    public virtual async Task<PagedResultDto<ListBankaDto>> GetListAsync(BankaListParameterDto input)
    {
        var entities = await _repository.GetPagedLastListAsync(input.SkipCount, input.MaxResultCount, b => b.Durum == input.Durum, b => b.Kod, b => b.OzelKod1, b => b.OzelKod2);

        var totalCount = await _repository.CountAsync(b => b.Durum == input.Durum);
        return new PagedResultDto<ListBankaDto>(totalCount, ObjectMapper.Map<List<Banka>, List<ListBankaDto>>(entities));
    }

    public virtual async Task<SelectBankaDto> UpdateAsync(Guid id, UpdateBankaDto input)
    {
        var entity = await _repository.GetAsync(id, b => b.Id == id);
        var mappedEntity = ObjectMapper.Map(input, entity);
        await _repository.UpdateAsync(mappedEntity);
        return ObjectMapper.Map<Banka, SelectBankaDto>(mappedEntity);
    }
}
