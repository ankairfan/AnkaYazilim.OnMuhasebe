﻿namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class BirimService : BaseService<ListBirimDto, SelectBirimDto>, IScopedDependency
{
    public override void SelectEntity(IEntityDto targetEntity)
    {
        switch (targetEntity)
        {
            case SelectHizmetDto hizmet:
                hizmet.BirimId = SelectedItem.Id;
                hizmet.BirimAdi = SelectedItem.Ad;
                break;

            case SelectMasrafDto masraf:
                masraf.BirimId = SelectedItem.Id;
                masraf.BirimAdi = SelectedItem.Ad;
                break;
        }
    }
}