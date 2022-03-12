namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class KasaService : BaseService<ListKasaDto, SelectKasaDto>, IScopedDependency
{
    public override void SelectEntity(IEntityDto targetEntity)
    {
        switch (targetEntity)
        {
            case SelectMakbuzHareketDto makbuzHareket:
                makbuzHareket.KasaId = SelectedItem.Id;
                makbuzHareket.KasaAdi = SelectedItem.Ad;
                break;
        
        }
    }
}
