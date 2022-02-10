namespace AnkaYazilim.OnMuhasebe;

public class OnMuhasebeApplicationAutoMapperProfile : Profile
{
    public OnMuhasebeApplicationAutoMapperProfile()
    {
        CreateMap<Banka, SelectBankaDto>();
        CreateMap<CreateBankaDto, Banka>();
    }
}
