namespace AnkaYazilim.OnMuhasebe.Services.Bankalar;

public class BankaAppService : OnMuhasebeAppService, IBankaAppService
{
    private readonly IBankaRepository _repository;

    public BankaAppService(IBankaRepository repository)
    {
        _repository = repository;
    }

    public async Task<SelectBankaDto> CreateAsync(CreateBankaDto input)
    {
        var entity = ObjectMapper.Map<CreateBankaDto, Banka>(input);
        await _repository.InsertAsync(entity);
        return ObjectMapper.Map<Banka, SelectBankaDto>(entity);
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<SelectBankaDto> GetAsync(Guid id)
    {
        var entity = await _repository.GetAsync(id, b => b.Id == id);
        return ObjectMapper.Map<Banka, SelectBankaDto>(entity);
    }

    public Task<string> GetCodeAsync(CodeParameterDto input)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResultDto<ListBankaDto>> GetListAsync(BankaListParameterDto input)
    {
        throw new NotImplementedException();
    }

    public Task<SelectBankaDto> UpdateAsync(Guid id, UpdateBankaDto input)
    {
        throw new NotImplementedException();
    }
}
