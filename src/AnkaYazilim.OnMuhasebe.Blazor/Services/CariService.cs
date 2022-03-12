﻿namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class CariService : BaseService<ListCariDto, SelectCariDto>, IScopedDependency
{
    public override void SelectEntity(IEntityDto targetEntity)
    {
        switch (targetEntity)
        {
            case SelectFaturaDto fatura:
                fatura.CariId = SelectedItem.Id;
                fatura.Unvan = SelectedItem.Unvan;
                break;
            case SelectMakbuzDto makbuz:
                makbuz.CariId = SelectedItem.Id;
                makbuz.Unvan = SelectedItem.Unvan;
                break;
        }
    }
}
