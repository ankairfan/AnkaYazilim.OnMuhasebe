﻿namespace AnkaYazilim.OnMuhasebe;

public class OnMuhasebeApplicationAutoMapperProfile : Profile
{
    public OnMuhasebeApplicationAutoMapperProfile()
    {
        //Banka
        CreateMap<Banka, SelectBankaDto>().ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
            .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<Banka, ListBankaDto>().ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
            .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<CreateBankaDto, Banka>();
        CreateMap<UpdateBankaDto, Banka>();

        //BankaSube
        CreateMap<BankaSube, SelectBankaSubeDto>().ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
            .ForMember(x => x.BankaAdi, y => y.MapFrom(z => z.Banka.Ad))
            .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<BankaSube, ListBankaSubeDto>().ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
            .ForMember(x => x.BankaAdi, y => y.MapFrom(z => z.Banka.Ad))
            .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<CreateBankaSubeDto, BankaSube>();
        CreateMap<UpdateBankaSubeDto, BankaSube>();

        //BankaHesap
        CreateMap<BankaHesap, SelectBankaHesapDto>()
          .ForMember(x => x.BankaId, y => y.MapFrom(z => z.BankaSube.Banka.Id))
        .ForMember(x => x.BankaAdi, y => y.MapFrom(z => z.BankaSube.Ad))
        .ForMember(x => x.BankaSubeAdi, y => y.MapFrom(z => z.BankaSube.Ad))
        .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
        .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<BankaHesap, ListBankaHesapDto>()
             .ForMember(x => x.BankaAdi, y => y.MapFrom(z => z.BankaSube.Ad))
        .ForMember(x => x.BankaSubeAdi, y => y.MapFrom(z => z.BankaSube.Ad))
        .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
        .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<CreateBankaHesapDto, BankaHesap>();
        CreateMap<UpdateBankaHesapDto, BankaHesap>();

        //Birim
        CreateMap<Birim, SelectBirimDto>()
             .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
        .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<Birim, ListBirimDto>()
             .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
        .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<CreateBirimDto, Birim>();
        CreateMap<UpdateBirimDto, Birim>();

        //Cari
        CreateMap<Cari, SelectCariDto>()
             .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
        .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<Cari, ListCariDto>()
             .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
        .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<CreateCariDto, Cari>();
        CreateMap<UpdateCariDto, Cari>();

        //Depo
        CreateMap<Depo, SelectDepoDto>()
             .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
        .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<Depo, ListDepoDto>()
             .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
        .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad))
        .ForMember(x => x.Giren, y => y.MapFrom(z => z.FaturaHareketleri.Where(x => x.Fatura.FaturaTuru == FaturaTuru.Alis).Sum(x => x.Miktar)))
        .ForMember(x => x.Cikan, y => y.MapFrom(z => z.FaturaHareketleri.Where(x => x.Fatura.FaturaTuru == FaturaTuru.satis).Sum(x => x.Miktar)));



        CreateMap<CreateDepoDto, Depo>();
        CreateMap<UpdateDepoDto, Depo>();

        //Dönem
        CreateMap<Donem, SelectDonemDto>();
        CreateMap<Donem, ListDonemDto>();
        CreateMap<CreateDonemDto, Donem>();
        CreateMap<UpdateDonemDto, Donem>();

        //Fatura
        CreateMap<Fatura, SelectFaturaDto>()
            .ForMember(x => x.CariAdi, y => y.MapFrom(z => z.Cari.Ad))
            .ForMember(x => x.VergiDairesi, y => y.MapFrom(z => z.Cari.VergiDairesi))
            .ForMember(x => x.VergiNumarasi, y => y.MapFrom(z => z.Cari.VergiNumarasi))
            .ForMember(x => x.TcNumarasi, y => y.MapFrom(z => z.Cari.TcNumarasi))
            .ForMember(x => x.Adres, y => y.MapFrom(z => z.Cari.Adres))
            .ForMember(x => x.TelefonNumarasi, y => y.MapFrom(z => z.Cari.Telefon))
             .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
        .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<Fatura, ListFaturaDto>()
            .ForMember(x => x.CariAdi, y => y.MapFrom(z => z.Cari.Ad))
             .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
        .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<CreateFaturaDto, Fatura>();
        CreateMap<UpdateFaturaDto, Fatura>()
            .ForMember(x => x.FaturaHareketleri, y => y.Ignore());

        //FaturaHareket
        CreateMap<FaturaHareket, SelectFaturaHareketDto>()
            .ForMember(x => x.StokKodu, y => y.MapFrom(z => z.Stok.Kod))
            .ForMember(x => x.StokAdi, y => y.MapFrom(z => z.Stok.Ad))
            .ForMember(x => x.HizmetKodu, y => y.MapFrom(z => z.Hizmet.Kod))
            .ForMember(x => x.HizmetAdi, y => y.MapFrom(z => z.Hizmet.Ad))
            .ForMember(x => x.MasrafKodu, y => y.MapFrom(z => z.Masraf.Kod))
            .ForMember(x => x.MasrafAdi, y => y.MapFrom(z => z.Masraf.Ad))
            .ForMember(x => x.DepoKodu, y => y.MapFrom(z => z.Depo.Kod))
            .ForMember(x => x.DepoAdi, y => y.MapFrom(z => z.Depo.Ad))

            .ForMember(x => x.BirimAdi, y => y.MapFrom(z => z.Stok != null ? z.Stok.Birim.Ad : z.Hizmet != null ? z.Hizmet.Birim.Ad : z.Masraf != null ? z.Masraf.Birim.Ad : null))
            .ForMember(x => x.HareketKodu, y => y.MapFrom(z => z.Stok != null ? z.Stok.Kod : z.Hizmet != null ? z.Hizmet.Kod : z.Masraf != null ? z.Masraf.Kod : null))
            .ForMember(x => x.HareketAdi, y => y.MapFrom(z => z.Stok != null ? z.Stok.Ad : z.Hizmet != null ? z.Hizmet.Ad : z.Masraf != null ? z.Masraf.Ad : null));

        CreateMap<FaturaHareketDto, FaturaHareket>();
    }
}
