global using System;
global using Volo.Abp.Identity;
global using Volo.Abp.TenantManagement;
global using Volo.Abp.Application.Dtos;
global using AnkaYazilim.OnMuhasebe.CommonDtos;
global using AnkaYazilim.OnMuhasebe.Faturalar;
global using AnkaYazilim.OnMuhasebe.Makbuzlar;
global using System.Collections.Generic;
global using AnkaYazilim.OnMuhasebe.DTOs.FaturaHareketler;
global using AnkaYazilim.OnMuhasebe.DTOs.Faturalar;
global using AnkaYazilim.OnMuhasebe.DTOs.MakbuzHareketler;
global using System.Threading.Tasks;
global using AnkaYazilim.OnMuhasebe.DTOs.Bankalar;
global using AnkaYazilim.OnMuhasebe.Entities.Finance.Banks;
global using AutoMapper;
global using AnkaYazilim.OnMuhasebe.DTOs.BankaSubeler;
global using AnkaYazilim.OnMuhasebe.Entities.Finance.BankaSubeler;
global using Volo.Abp.Domain.Repositories;
global using AnkaYazilim.OnMuhasebe.DTOs.BankaHesaplar;
global using System.Linq;
global using AnkaYazilim.OnMuhasebe.Entities.Finance.BankaHesaplar;
global using AnkaYazilim.OnMuhasebe.DTOs.Birimler;
global using AnkaYazilim.OnMuhasebe.Entities.Stocks.Birimler;
global using AnkaYazilim.OnMuhasebe.DTOs.Cariler;
global using AnkaYazilim.OnMuhasebe.Entities.Sales.Cariler;
global using AnkaYazilim.OnMuhasebe.DTOs.Depolar;
global using AnkaYazilim.OnMuhasebe.Entities.Stocks.Depolar;
global using AnkaYazilim.OnMuhasebe.DTOs.Donemler;
global using AnkaYazilim.OnMuhasebe.Entities.Parameters.Donemler;
global using AnkaYazilim.OnMuhasebe.Entities.Sales.Faturalar;
global using AnkaYazilim.OnMuhasebe.DTOs.Hizmetler;
global using AnkaYazilim.OnMuhasebe.Entities.Hizmetler;
global using AnkaYazilim.OnMuhasebe.DTOs.Kasalar;
global using AnkaYazilim.OnMuhasebe.Entities.Finance.Kasalar;
global using AnkaYazilim.OnMuhasebe.DTOs.Makbuzlar;
global using AnkaYazilim.OnMuhasebe.Entities.Finance.Makbuzlar;
global using AnkaYazilim.OnMuhasebe.DTOs.Masraflar;
global using AnkaYazilim.OnMuhasebe.Entities.Masraflar;
global using AnkaYazilim.OnMuhasebe.DTOs.OzelKodlar;
global using AnkaYazilim.OnMuhasebe.Entities.OzelKodlar;
global using AnkaYazilim.OnMuhasebe.DTOs.Parametreler;
global using AnkaYazilim.OnMuhasebe.Entities.Parameters.FirmalarParametre;
global using AnkaYazilim.OnMuhasebe.DTOs.Stoklar;
global using AnkaYazilim.OnMuhasebe.Entities.Stocks.Stoklar;
global using AnkaYazilim.OnMuhasebe.DTOs.Subeler;
global using AnkaYazilim.OnMuhasebe.Entities.Subeler;





