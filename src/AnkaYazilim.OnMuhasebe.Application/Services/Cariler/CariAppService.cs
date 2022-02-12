namespace AnkaYazilim.OnMuhasebe.Services.Cariler;

public class CariAppService : OnMuhasebeAppService, ICariAppService
{
    private readonly ICariRepository _repository;
    private readonly CariManager _manager;
    public CariAppService(ICariRepository repository, CariManager manager)
    {
        _repository = repository;
        _manager = manager;
    }

    public virtual async Task<SelectCariDto> GetAsync(Guid id)
    {
        var entity = await _repository.GetAsync(id, x => x.Id == id, x => x.OzelKod1, x => x.OzelKod2);
        return ObjectMapper.Map<Cari, SelectCariDto>(entity);
    }

    public virtual async Task<PagedResultDto<ListCariDto>> GetListAsync(CariListParameterDto input)
    {
        var entities = await _repository.GetPagedListAsync(input.SkipCount, input.MaxResultCount,
            x => x.Durum == input.Durum, x => x.Kod, x => x.OzelKod1, x => x.OzelKod2, x => x.Faturalar, x => x.Makbuzlar);

        var totalCount = await _repository.CountAsync(x => x.Durum == input.Durum);

        var mappedDtos = ObjectMapper.Map<List<Cari>, List<ListCariDto>>(entities);

        mappedDtos.ForEach(x =>
        {
            x.Borc = x.Faturalar.Where(y => y.FaturaTuru == FaturaTuru.satis).Sum(y => y.NetTutar);
            x.Borc += x.Makbuzlar.Where(y => y.MakbuzTuru == MakbuzTuru.Odeme).Sum(y => y.CekToplamTutar + y.SenetToplamTutar + y.PosToplamTutar + y.NakitToplamTutar + y.BankaToplamTutar);

            x.Alacak = x.Faturalar.Where(y => y.FaturaTuru == FaturaTuru.Alis).Sum(y => y.NetTutar);
            x.Alacak += x.Makbuzlar.Where(y => y.MakbuzTuru == MakbuzTuru.Tahsilat).Sum(y => y.CekToplamTutar + y.SenetToplamTutar + y.PosToplamTutar + y.NakitToplamTutar + y.BankaToplamTutar);

        });

        return new PagedResultDto<ListCariDto>(totalCount, mappedDtos);
    }

    public virtual async Task<SelectCariDto> CreateAsync(CreateCariDto input)
    {
        await _manager.CheckCreateAsync(input.Kod, input.OzelKod1Id, input.OzelKod2Id);
        var entity = ObjectMapper.Map<CreateCariDto, Cari>(input);
        await _repository.InsertAsync(entity);
        return ObjectMapper.Map<Cari, SelectCariDto>(entity);
    }

    public virtual async Task<SelectCariDto> UpdateAsync(Guid id, UpdateCariDto input)
    {
        var entity = await _repository.GetAsync(id, x => x.Id == id);
        await _manager.CheckUpdateAsync(id, input.Kod, entity, input.OzelKod1Id, input.OzelKod2Id);
        var mappedEntity = ObjectMapper.Map(input, entity);
        await _repository.UpdateAsync(mappedEntity);
        return ObjectMapper.Map<Cari, SelectCariDto>(mappedEntity);
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
