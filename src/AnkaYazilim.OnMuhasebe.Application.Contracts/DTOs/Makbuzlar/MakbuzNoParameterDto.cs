﻿namespace AnkaYazilim.OnMuhasebe.DTOs.Makbuzlar;

public class MakbuzNoParameterDto:IDurum,IEntityDto
{
    public MakbuzTuru MakbuzTuru { get; set; }
    public Guid SubeId { get; set; }
    public Guid DonemId { get; set; }
    public bool Durum { get; set; }
}
