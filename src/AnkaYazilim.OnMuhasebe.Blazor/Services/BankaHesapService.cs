using AnkaYazilim.OnMuhasebe.DTOs.MakbuzHareketler;

namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class BankaHesapService : BaseService<ListBankaHesapDto, SelectBankaHesapDto>, IScopedDependency
{
    public BankaHesapTuru? HesapTuru { get; set; }

    public void BankaHesapTuruSelectedItemChanged(ComboBoxEnumItem<BankaHesapTuru> selectedItem)

    {
        DataSource.HesapTuru = selectedItem.Value;
    }

    //public override void SelectEntity(IEntityDto targetEntity)
    //{
    //    switch (targetEntity)
    //    {
    //        case SelectMakbuzHareketDto makbuzHareket:
    //            makbuzHareket.BankaHesapId = SelectedItem.Id;
    //            makbuzHareket.BankaHesapAdi = SelectedItem.Ad;
    //            break;

    //        case SelectMakbuzDto makbuz:
    //            makbuz.BankaHesapId = SelectedItem.Id;
    //            makbuz.BankaHesapAdi = SelectedItem.Ad;
    //            break;
    //    }
    //}
}