namespace AnkaYazilim.OnMuhasebe.Blazor.Pages.Base;

public abstract class BaseUpdatePage<TGetOutputDto, TGetListOutputDto, TGetListInput, TCreateInput, TUpdateInput, TGetCodeInput> : AbpComponentBase
where TGetOutputDto : class, IEntityDto<Guid>, new()
where TGetListOutputDto : class, IEntityDto<Guid>
where TGetListInput : class, IEntityDto, IDurum, new()
where TCreateInput : class, IEntityDto, new()
where TUpdateInput : class, IEntityDto
where TGetCodeInput : class, IEntityDto, IDurum, new()
{
}