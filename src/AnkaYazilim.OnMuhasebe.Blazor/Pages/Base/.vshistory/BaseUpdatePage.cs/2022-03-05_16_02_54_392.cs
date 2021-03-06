namespace AnkaYazilim.OnMuhasebe.Blazor.Pages.Base;

public abstract class BaseUpdatePage<TGetOutputDto, TGetListOutputDto, TGetListInput, TCreateInput, TUpdateInput, TGetCodeInput> : AbpComponentBase
where TGetOutputDto : class, IEntityDto
where TGetListOutputDto : class, IEntityDto
where TGetListInput : class, IEntityDto
where TCreateInput : class, IEntityDto
where TUpdateInput : class, IEntityDto
{
    #region Services

    protected ICrudAppService<TGetOutputDto, TGetListOutputDto, TGetListInput, TCreateInput, TUpdateInput> BaseCrudService { get; set; }

    #endregion Services

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

    #endregion CrudFunctions
}