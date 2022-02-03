﻿namespace AnkaYazilim.OnMuhasebe.Entities.Sales.Faturalar;

public class FaturaHareket:FullAuditedEntity<Guid>
{
    public Guid FaturaId { get; set; }
    public FaturaHareketTuru HareketTuru { get;}
    public Guid? StokId { get; set; }
    public Guid? HizmetId { get; set; }
    public Guid? MasrafId { get; set; }
    public Guid? DepoId { get; set; }
    public decimal Miktar { get; set; }
    public decimal Fiyat { get; set; }
    public byte? IndirimOran { get; set; }
    public byte? KdvOran { get; set; }
    public decimal BrutTutar { get; set; }
    public decimal? IndirimTutar { get; set; }
    public decimal NetTutar { get; set; }
    public decimal? KdvTutar { get; set; }
    public decimal GenelTutar { get; set; }
    public string Aciklama { get; set; }

}
