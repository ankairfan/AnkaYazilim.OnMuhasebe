﻿namespace AnkaYazilim.OnMuhasebe.DTOs.Masraflar;

public class SelectMasrafDto:EntityDto<Guid>, IOzelKod
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public byte KdvOran { get; set; }
    public decimal? BirimFiyat { get; set; }
    public Guid? BirimId { get; set; }
    public string BirimAdi { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public string OzelKod1Adi { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public string OzelKod2Adi { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }
}

