﻿namespace AnkaYazilim.OnMuhasebe.DTOs.Hizmetler;

public class CreateHizmetDto:IEntityDto
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public byte? KdvOrani { get; set; }
    public decimal? BirimFiyat { get; set; }
    public string Barkod { get; set; }
    public Guid? BirimId { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }
}