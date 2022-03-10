namespace AnkaYazilim.OnMuhasebe.Services.Makbuzlar;

public class MakbuzAppService : OnMuhasebeAppService, IMakbuzAppService
{
    private readonly IMakbuzRepository _repository;
    private readonly MakbuzManager _manager;
    private readonly MakbuzHareketManager _hareketManager;
    public MakbuzAppService(IMakbuzRepository repository, MakbuzManager manager, MakbuzHareketManager hareketManager)
    {
        _repository = repository;
        _manager = manager;
        _hareketManager = hareketManager;
    }

    public virtual async Task<SelectMakbuzDto> GetAsync(Guid id)
    {
        var entity = await _repository.GetAsync(id, x => x.Id == id);
        var mappedDto = ObjectMapper.Map<Makbuz, SelectMakbuzDto>(entity);

        mappedDto.MakbuzHareketler.ForEach(m =>
        {
            m.OdemeTuruAdi = L[$"Enum:OdemeTuru:{(byte)m.OdemeTuru}"];
            m.BelgeDurumuAdi = L[$"Enum:BelgeDurumu:{(byte)m.BelgeDurumu}"];
        });
        return mappedDto;
    }

    public virtual async Task<PagedResultDto<ListMakbuzDto>> GetListAsync(MakbuzListParameterDto input)
    {
        var entities = await _repository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, x => x.MakbuzTuru == input.MakbuzTuru && x.SubeId ==
          input.SubeId && x.DonemId == input.DonemId && x.Durum == input.Durum, x => x.MakbuzNo, x => x.Cari, x => x.Kasa, x => x.BankaHesap, x => x.OzelKod1, x => x.OzelKod2);

        var totalCount = await _repository.CountAsync(x => x.MakbuzTuru == input.MakbuzTuru && x.SubeId ==
           input.SubeId && x.DonemId == input.DonemId && x.Durum == input.Durum);

        return new PagedResultDto<ListMakbuzDto>(totalCount, ObjectMapper.Map<List<Makbuz>, List<ListMakbuzDto>>(entities));
    }
    public virtual async Task<SelectMakbuzDto> CreateAsync(CreateMakbuzDto input)
    {
        await _manager.CheckCreateAsync(input.MakbuzNo, input.MakbuzTuru.Value, input.CariId, input.KasaId, input.BankaHesapId,
            input.OzelKod1Id, input.OzelKod2Id, input.SubeId, input.DonemId);

        foreach (var makbuzHareket in input.MakbuzHareketler)
        {
            await _hareketManager.CheckCreateAsync(makbuzHareket.CekBankaId, makbuzHareket.CekBankaSubeId, makbuzHareket.KasaId, makbuzHareket.BankaHesapId);
        }

        var entity = ObjectMapper.Map<CreateMakbuzDto, Makbuz>(input);
        await _repository.InsertAsync(entity);
        return ObjectMapper.Map<Makbuz, SelectMakbuzDto>(entity);
    }

    public virtual async Task<SelectMakbuzDto> UpdateAsync(Guid id, UpdateMakbuzDto input)
    {
        var entity = await _repository.GetAsync(id, x => x.Id == id, x => x.MakbuzHareketleri);

        await _manager.CheckUpdateAsync(id, input.MakbuzNo, entity, input.CariId, input.KasaId, input.BankaHesapId, input.OzelKod1Id, input.OzelKod2Id);

        foreach (var makbuzHareketDto in input.MakbuzHareketler)
        {
            await _hareketManager.CheckUpdateAsync(makbuzHareketDto.CekBankaId, makbuzHareketDto.CekBankaSubeId, makbuzHareketDto.KasaId, makbuzHareketDto.BankaHesapId);

            var makbuzHareket = entity.MakbuzHareketleri.FirstOrDefault(x => x.Id == makbuzHareketDto.Id);

            if (makbuzHareket == null)
            {
                entity.MakbuzHareketleri.Add(ObjectMapper.Map<MakbuzHareketDto, MakbuzHareket>(makbuzHareketDto));
                continue;
            }
            ObjectMapper.Map(makbuzHareketDto, makbuzHareket);
        }

        var deletedEntities = entity.MakbuzHareketleri.Where(x => input.MakbuzHareketler.Select(y => y.Id).ToList().IndexOf(x.Id) == -1);
        entity.MakbuzHareketleri.RemoveAll(deletedEntities);
        ObjectMapper.Map(input, entity);
        await _repository.UpdateAsync(entity);
        return ObjectMapper.Map<Makbuz, SelectMakbuzDto>(entity);
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await _repository.GetAsync(id, x => x.Id == id, x => x.MakbuzHareketleri);
        await _repository.DeleteAsync(entity);
        entity.MakbuzHareketleri.RemoveAll(entity.MakbuzHareketleri);
    }

    public virtual async Task<string> GetCodeAsync(MakbuzNoParameterDto input)
    {
        return await _repository.GetCodeAsync(x => x.MakbuzNo, x => x.MakbuzTuru == input.MakbuzTuru && x.SubeId == input.SubeId && x.DonemId == input.DonemId && x.Durum == input.Durum);
    }
}
