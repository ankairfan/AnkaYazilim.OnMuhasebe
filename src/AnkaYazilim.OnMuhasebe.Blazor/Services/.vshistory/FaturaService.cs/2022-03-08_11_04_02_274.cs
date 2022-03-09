﻿namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class FaturaService : BaseService<ListFaturaDto, SelectFaturaDto>, IScopedDependency
{
    public override void FillTable<TItem>(ICoreHareketService<TItem> hareketService, Action hasChanged)
    {
        if (hareketService is FaturaHareketService faturaHareketService)
        {
            faturaHareketService.ListDataSource = DataSource.FaturaHareketler ?? new List<DTOs.FaturaHareketler.SelectFaturaHareketDto>();
            faturaHareketService.HasChanged = hasChanged;
            faturaHareketService.GetTotal();
        }
    }
}