namespace AnkaYazilim.OnMuhasebe.Services;

public interface ICodeAppService<in TGetCodeInput>:IApplicationService
{
    Task<string> GetCodeAsync(TGetCodeInput input);
}
