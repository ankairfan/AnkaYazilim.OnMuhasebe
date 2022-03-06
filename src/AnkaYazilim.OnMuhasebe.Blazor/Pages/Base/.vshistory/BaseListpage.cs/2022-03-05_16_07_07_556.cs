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

    protected ICrudAppService<TGetOutputDto, TGetListOutputDto, TGetListInput,
        TCreateInput, TUpdateInput, TGetCodeInput> BaseCrudService
    { get; set; }

    public BaseService<TGetListOutputDto, TGetOutputDto> BaseService { get; set; }

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

    #endregion CrudFunctions

    protected override async Task OnParametersSetAsync()
    {
        await GetListDataSourceAsync();
        BaseService.HasChanged = StateHasChanged;
    }

    protected override void OnAfterRender(bool firstRender)
    {
        BaseService.ShowListPage(firstRender);
    }

    protected virtual async Task GetListDataSourceAsync()
    {
        BaseService.ListDataSource = (await GetListAsync(new TGetListInput
        {
            Durum = BaseService.IsActiveCards
        })).Items.ToList();
        BaseService.IsLoaded = true;
    }

    protected virtual async Task DeleteAsync()
    {
        BaseService.SelectFirstDataRow = false;

        await BaseService.ConfirmMessage(L["DeleteConfirmMessage"], async () =>
        {
            await DeleteAsync(BaseService.SelectedItem.Id);
            var deletedEntityIndex = BaseService.ListDataSource.FindIndex(x => x.GetEntityId() == BaseService.SelectedItem.GetEntityId());

            await GetListDataSourceAsync();
            BaseService.HasChanged();

            if (BaseService.ListDataSource.Count > 0)
                BaseService.SelectedItem = BaseService.ListDataSource.SetSelectedItem(deletedEntityIndex);
        }, L["DeleteConfirmMessageTitle"]);
    }

    protected virtual async Task BeforeInsertAsync()
    {
        BaseService.DataSource = new TGetOutputDto();

        var kod = typeof(TGetOutputDto).GetProperty("Kod");
        var durum = typeof(TGetOutputDto).GetProperty("Durum");

        if (kod != null)
            kod.SetValue(BaseService.DataSource, await GetCodeAsync(new TGetCodeInput { Durum = BaseService.IsActiveCards }));

        if (durum != null)
            durum.SetValue(BaseService.DataSource, BaseService.IsActiveCards);

        BaseService.ShowEditpage();
    }

    protected virtual async Task BeforeUpdateAsync()
    {
        if (BaseService.ListDataSource.Count == 0) return;

        BaseService.SelectFirstDataRow = false;
        BaseService.DataSource = await GetAsync(BaseService.SelectedItem.Id);
        BaseService.EditPageVisible = true;
        await InvokeAsync(BaseService.HasChanged);
    }

    protected virtual async Task OnSubmit()
    {
        TGetOutputDto result;

        if (BaseService.DataSource.Id == Guid.Empty)
        {
            var createInput = ObjectMapper.Map<TGetOutputDto, TCreateInput>(
                BaseService.DataSource);

            result = await CreateAsync(createInput);
        }
        else
        {
            var updateInput = ObjectMapper.Map<TGetOutputDto, TUpdateInput>(
                BaseService.DataSource);

            result = await UpdateAsync(BaseService.DataSource.Id, updateInput);
        }

        if (result == null) return;

        var savedEntityIndex = BaseService.ListDataSource.FindIndex(
            x => x.Id == BaseService.DataSource.Id);

        await GetListDataSourceAsync();
        BaseService.HideEditPage();

        if (BaseService.DataSource.Id == Guid.Empty)
            BaseService.DataSource.Id = result.Id;

        if (savedEntityIndex > -1)
            BaseService.SelectedItem = BaseService.ListDataSource.
                SetSelectedItem(savedEntityIndex);
        else
            BaseService.SelectedItem = BaseService.ListDataSource.
                GetEntityById(BaseService.DataSource.Id);
    }
}