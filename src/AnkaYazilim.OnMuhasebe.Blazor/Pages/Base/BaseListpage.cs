namespace AnkaYazilim.OnMuhasebe.Blazor.Pages.Base;

public abstract class BaseListpage<TGetOutputDto, TGetListOutputDto, TGetListInput, TCreateInput, TUpdateInput, TGetCodeInput> : AbpComponentBase
where TGetOutputDto : class, IEntityDto<Guid>, new()
where TGetListOutputDto : class, IEntityDto<Guid>
where TGetListInput : class, IEntityDto, IDurum, new()
where TCreateInput : class, IEntityDto, new()
where TUpdateInput : class, IEntityDto
where TGetCodeInput : class, IEntityDto, IDurum, new()
{
    public BaseListpage()
    {
        LocalizationResource = typeof(OnMuhasebeResource);
    }

    #region Services
    protected ICrudAppService<TGetOutputDto, TGetListOutputDto, TGetListInput, TCreateInput, TUpdateInput, TGetCodeInput> BaseCrudService { get; set; }
    public BaseService<TGetListOutputDto, TGetOutputDto> BaseService { get; set; }
    #endregion

    #region CrudFunctions
    protected async Task<TGetOutputDto> GetAsync(Guid id)
    {
        try
        {
            return await BaseCrudService.GetAsync(id);
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
        return default;
    }

    protected async Task<PagedResultDto<TGetListOutputDto>> GetListAsync(TGetListInput input)
    {
        try
        {
            return await BaseCrudService.GetListAsync(input);
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
        return default;
    }

    protected async Task<TGetOutputDto> CreateAsync(TCreateInput input)
    {
        try
        {
            return await BaseCrudService.CreateAsync(input);
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }

        return default;
    }

    protected async Task<TGetOutputDto> UpdateAsync(Guid id, TUpdateInput input)
    {
        try
        {
            return await BaseCrudService.UpdateAsync(id, input);
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }

        return default;
    }

    protected async Task DeleteAsync(Guid id)
    {
        try
        {
            await BaseCrudService.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }

    }

    protected async Task<string> GetCodeAsync(TGetCodeInput input)
    {
        try
        {
            return await BaseCrudService.GetCodeAsync(input);
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }

        return default;
    }
    #endregion
}
