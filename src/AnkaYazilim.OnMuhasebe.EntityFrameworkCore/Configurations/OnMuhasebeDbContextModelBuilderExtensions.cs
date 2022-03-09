namespace AnkaYazilim.OnMuhasebe.Configurations;

public static class OnMuhasebeDbContextModelBuilderExtensions
{
    public static void Configure(this ModelBuilder builder)
    {
        builder.Entity<Banka>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Bankalar", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.Kod).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxKodLength);

            b.Property(x => x.Ad).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAdLength);

            b.Property(x => x.OzelKod1Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.OzelKod2Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            b.Property(x => x.Durum).HasColumnType(SqlDbType.Bit.ToString());

            //indexes
            b.HasIndex(x => x.Kod);

            //relations
            b.HasOne(x => x.OzelKod1).WithMany(x => x.OzelKod1Bankalar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.OzelKod2).WithMany(x => x.OzelKod2Bankalar).OnDelete(DeleteBehavior.NoAction);
        });
    }

    public static void ConfigureBanka(this ModelBuilder builder)
    {
        builder.Entity<Banka>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Bankalar", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.Kod).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxKodLength);

            b.Property(x => x.Ad).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAdLength);

            b.Property(x => x.OzelKod1Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.OzelKod2Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            b.Property(x => x.Durum).HasColumnType(SqlDbType.Bit.ToString());

            //indexes
            b.HasIndex(x => x.Kod);

            //relations
            b.HasOne(x => x.OzelKod1).WithMany(x => x.OzelKod1Bankalar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.OzelKod2).WithMany(x => x.OzelKod2Bankalar).OnDelete(DeleteBehavior.NoAction);
        });
    }

    public static void ConfigureBankaSube(this ModelBuilder builder)
    {
        builder.Entity<BankaSube>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "BankaSubeler", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.Kod).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxKodLength);

            b.Property(x => x.Ad).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAdLength);

            b.Property(x => x.BankaId).IsRequired().HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.OzelKod1Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.OzelKod2Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            b.Property(x => x.Durum).HasColumnType(SqlDbType.Bit.ToString());

            //indexes
            b.HasIndex(x => x.Kod);

            //relations

            b.HasOne(x => x.Banka).WithMany(x => x.BankaSubeler).OnDelete(DeleteBehavior.Cascade);

            b.HasOne(x => x.OzelKod1).WithMany(x => x.OzelKod1BankaSubeler).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.OzelKod2).WithMany(x => x.OzelKod2BankaSubeler).OnDelete(DeleteBehavior.NoAction);
        });
    }

    public static void ConfigureBankaHesap(this ModelBuilder builder)
    {
        builder.Entity<BankaHesap>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "BankaHesaplar", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.Kod).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxKodLength);

            b.Property(x => x.Ad).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAdLength);

            b.Property(x => x.HesapTuru).IsRequired().HasColumnType(SqlDbType.TinyInt.ToString());

            b.Property(x => x.HesapNo).IsRequired().HasColumnType(SqlDbType.VarChar.ToString()).HasMaxLength(BankaHesapConsts.MaxHesapLength);

            b.Property(x => x.IbanNo).HasColumnType(SqlDbType.VarChar.ToString()).HasMaxLength(BankaHesapConsts.MaxIbanNoLength);

            b.Property(x => x.BankaSubeId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.SubeId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.OzelKod1Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.OzelKod2Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            b.Property(x => x.Durum).HasColumnType(SqlDbType.Bit.ToString());

            //indexes
            b.HasIndex(x => x.Kod);

            //relations
            b.HasOne(x => x.OzelKod1).WithMany(x => x.OzelKod1BankaHesaplar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.OzelKod2).WithMany(x => x.OzelKod2BankaHesaplar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.BankaSube).WithMany(x => x.BankaHesaplar).OnDelete(DeleteBehavior.Cascade);

            b.HasOne(x => x.Sube).WithMany(x => x.BankaHesaplar).OnDelete(DeleteBehavior.Cascade);
        });
    }

    public static void ConfigureBirim(this ModelBuilder builder)
    {
        builder.Entity<Birim>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Birimler", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.Kod).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxKodLength);

            b.Property(x => x.Ad).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAdLength);

            b.Property(x => x.OzelKod1Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.OzelKod2Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            b.Property(x => x.Durum).HasColumnType(SqlDbType.Bit.ToString());

            //indexes
            b.HasIndex(x => x.Kod);

            //relations
            b.HasOne(x => x.OzelKod1).WithMany(x => x.OzelKod1Birimler).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.OzelKod2).WithMany(x => x.OzelKod2Birimler).OnDelete(DeleteBehavior.NoAction);
        });
    }

    public static void ConfigureCari(this ModelBuilder builder)
    {
        builder.Entity<Cari>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Cariler", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.Kod).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxKodLength);

            b.Property(x => x.Unvan).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(CariConsts.MaxUnvanLength);

            b.Property(x => x.OzelKod1Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.OzelKod2Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            b.Property(x => x.Ad).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAdLength);

            b.Property(x => x.Soyad).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(CariConsts.MaxSoyadLength);

            b.Property(x => x.VergiDairesi).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(CariConsts.MaxVergiDairesiLength);

            b.Property(x => x.VergiNumarasi).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(CariConsts.MaxVergiNoLength);

            b.Property(x => x.TcNumarasi).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(CariConsts.MaxTcNoLength);

            b.Property(x => x.Adres).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAdresLength);

            b.Property(x => x.Telefon).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxTelefonLength);

            b.Property(x => x.MobilTelefon).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxTelefonLength);

            b.Property(x => x.Email).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(CariConsts.MaxWebLength);

            b.Property(x => x.Durum).HasColumnType(SqlDbType.Bit.ToString());

            //indexes
            b.HasIndex(x => x.Kod);

            //relations
            b.HasOne(x => x.OzelKod1).WithMany(x => x.OzelKod1Cariler).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.OzelKod2).WithMany(x => x.OzelKod2Cariler).OnDelete(DeleteBehavior.NoAction);
        });
    }

    public static void ConfigureDepo(this ModelBuilder builder)
    {
        builder.Entity<Depo>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Depolar", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.Kod).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxKodLength);

            b.Property(x => x.Ad).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAdLength);

            b.Property(x => x.OzelKod1Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.OzelKod2Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.SubeId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            b.Property(x => x.Durum).HasColumnType(SqlDbType.Bit.ToString());

            //indexes
            b.HasIndex(x => x.Kod);

            //relations
            b.HasOne(x => x.OzelKod1).WithMany(x => x.OzelKod1Depolar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.OzelKod2).WithMany(x => x.OzelKod2Depolar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Sube).WithMany(x => x.Depolar).OnDelete(DeleteBehavior.Cascade);
        });
    }

    public static void ConfigureDonem(this ModelBuilder builder)
    {
        builder.Entity<Donem>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Donemler", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.Kod).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxKodLength);

            b.Property(x => x.Ad).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAdLength);

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            b.Property(x => x.Durum).HasColumnType(SqlDbType.Bit.ToString());

            //indexes
            b.HasIndex(x => x.Kod);

            //relations
        });
    }

    public static void ConfigureFatura(this ModelBuilder builder)
    {
        builder.Entity<Fatura>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Faturalar", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.FaturaTuru).IsRequired().
            HasColumnType(SqlDbType.TinyInt.ToString());

            b.Property(x => x.FaturaNo).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(FaturaConsts.MaxFaturaNoLength);

            b.Property(x => x.Tarih).IsRequired().
            HasColumnType(SqlDbType.Date.ToString());

            b.Property(x => x.BrutTutar).IsRequired().
            HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.IndirimTutari).IsRequired().
            HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.NetTutar).IsRequired().
            HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.KdvTutar).IsRequired().
            HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.GenelTutar).IsRequired().
            HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.HareketSayisi).IsRequired().
            HasColumnType(SqlDbType.Int.ToString());

            b.Property(x => x.OzelKod1Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.OzelKod2Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.CariId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.DonemId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.SubeId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            b.Property(x => x.Durum).HasColumnType(SqlDbType.Bit.ToString());

            //indexes
            b.HasIndex(x => x.FaturaNo);

            //relations
            b.HasOne(x => x.OzelKod1).WithMany(x => x.OzelKod1Faturalar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.OzelKod2).WithMany(x => x.OzelKod2Faturalar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Cari).WithMany(x => x.Faturalar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Donem).WithMany(x => x.Faturalar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Sube).WithMany(x => x.Faturalar).OnDelete(DeleteBehavior.NoAction);
        });
    }

    public static void ConfigureFaturaHareket(this ModelBuilder builder)
    {
        builder.Entity<FaturaHareket>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "FaturaHareketleri", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.HareketTuru).IsRequired().
            HasColumnType(SqlDbType.TinyInt.ToString());

            b.Property(x => x.FaturaId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.StokId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.HizmetId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.MasrafId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.DepoId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            b.Property(x => x.Miktar).HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.AlisFiyat).HasColumnType(SqlDbType.Money.ToString());
            b.Property(x => x.SatisFiyat).HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.IndirimOran).HasColumnType(SqlDbType.TinyInt.ToString());

            b.Property(x => x.KdvOran).HasColumnType(SqlDbType.TinyInt.ToString());

            b.Property(x => x.BrutTutar).HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.IndirimTutar).HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.NetTutar).HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.KdvTutar).HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.GenelTutar).HasColumnType(SqlDbType.Money.ToString());

            //indexes

            //relations
            b.HasOne(x => x.Fatura).WithMany(x => x.FaturaHareketleri).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Stok).WithMany(x => x.FaturaHareketleri).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Hizmet).WithMany(x => x.FaturaHareketleri).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Masraf).WithMany(x => x.FaturaHareketleri).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Depo).WithMany(x => x.FaturaHareketleri).OnDelete(DeleteBehavior.NoAction);
        });
    }

    public static void ConfigureFirmaParametre(this ModelBuilder builder)
    {
        builder.Entity<FirmaParametre>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "FirmaParametreleri", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties

            b.Property(x => x.UserId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.SubeId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.DonemId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.DepoId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            //indexes

            //relations
            b.HasOne(x => x.Sube).WithMany(x => x.FirmaParametreleri).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Donem).WithMany(x => x.FirmaParametreleri).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Depo).WithMany(x => x.FirmaParametreleri).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.User).WithOne().HasForeignKey<FirmaParametre>(x => x.UserId);
        });
    }

    public static void ConfigureHizmet(this ModelBuilder builder)
    {
        builder.Entity<Hizmet>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Hizmetler", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.Kod).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxKodLength);

            b.Property(x => x.Ad).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAdLength);

            b.Property(x => x.OzelKod1Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.OzelKod2Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.BirimId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.KdvOran).HasColumnType(SqlDbType.TinyInt.ToString());

            b.Property(x => x.AlisFiyat).HasColumnType(SqlDbType.Money.ToString());
            b.Property(x => x.SatisFiyat).HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            b.Property(x => x.Barkod).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxBarkodLength);

            b.Property(x => x.Durum).HasColumnType(SqlDbType.Bit.ToString());

            //indexes
            b.HasIndex(x => x.Kod);

            //relations
            b.HasOne(x => x.OzelKod1).WithMany(x => x.OzelKod1Hizmetler).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.OzelKod2).WithMany(x => x.OzelKod2Hizmetler).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Birim).WithMany(x => x.Hizmetler).OnDelete(DeleteBehavior.NoAction);
        });
    }

    public static void ConfigureKasa(this ModelBuilder builder)
    {
        builder.Entity<Kasa>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Kasalar", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.Kod).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxKodLength);

            b.Property(x => x.Ad).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAdLength);

            b.Property(x => x.OzelKod1Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.OzelKod2Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.SubeId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            b.Property(x => x.Durum).HasColumnType(SqlDbType.Bit.ToString());

            //indexes
            b.HasIndex(x => x.Kod);

            //relations
            b.HasOne(x => x.OzelKod1).WithMany(x => x.OzelKod1Kasalar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.OzelKod2).WithMany(x => x.OzelKod2Kasalar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Sube).WithMany(x => x.Kasalar).OnDelete(DeleteBehavior.NoAction);
        });
    }

    public static void ConfigureSube(this ModelBuilder builder)
    {
        builder.Entity<Sube>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Subeler", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.Kod).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxKodLength);

            b.Property(x => x.Ad).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAdLength);

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            b.Property(x => x.Durum).HasColumnType(SqlDbType.Bit.ToString());

            //indexes
            b.HasIndex(x => x.Kod);

            //relations
        });
    }

    public static void ConfigureStok(this ModelBuilder builder)
    {
        builder.Entity<Stok>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Stoklar", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.Kod).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxKodLength);

            b.Property(x => x.Ad).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAdLength);

            b.Property(x => x.OzelKod1Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.OzelKod2Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.BirimId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            b.Property(x => x.Barkod).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxBarkodLength);

            b.Property(x => x.Durum).HasColumnType(SqlDbType.Bit.ToString());

            b.Property(x => x.KdvOran).HasColumnType(SqlDbType.TinyInt.ToString());

            b.Property(x => x.SatisFiyat).HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.AlisFiyat).HasColumnType(SqlDbType.Money.ToString());

            //indexes
            b.HasIndex(x => x.Kod);

            //relations
            b.HasOne(x => x.OzelKod1).WithMany(x => x.OzelKod1Stoklar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.OzelKod2).WithMany(x => x.OzelKod2Stoklar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Birim).WithMany(x => x.Stoklar).OnDelete(DeleteBehavior.NoAction);
        });
    }

    public static void ConfigureOzelKod(this ModelBuilder builder)
    {
        builder.Entity<OzelKod>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "OzelKodlar", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.Kod).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxKodLength);

            b.Property(x => x.Ad).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAdLength);

            b.Property(x => x.KodTuru).HasColumnType(SqlDbType.TinyInt.ToString());

            b.Property(x => x.KartTuru).HasColumnType(SqlDbType.TinyInt.ToString());

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            b.Property(x => x.Durum).HasColumnType(SqlDbType.Bit.ToString());

            //indexes
            b.HasIndex(x => x.Kod);

            //relations
        });
    }

    public static void ConfigureMasraf(this ModelBuilder builder)
    {
        builder.Entity<Masraf>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Masraflar", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.Kod).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxKodLength);

            b.Property(x => x.Ad).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAdLength);

            b.Property(x => x.KdvOran).HasColumnType(SqlDbType.TinyInt.ToString());

            b.Property(x => x.AlisFiyat).HasColumnType(SqlDbType.Money.ToString());
            b.Property(x => x.SatisFiyat).HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.OzelKod1Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.OzelKod2Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.BirimId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            b.Property(x => x.Durum).HasColumnType(SqlDbType.Bit.ToString());

            //indexes
            b.HasIndex(x => x.Kod);

            //relations
            b.HasOne(x => x.OzelKod1).WithMany(x => x.OzelKod1Masraflar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.OzelKod2).WithMany(x => x.OzelKod2Masraflar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Birim).WithMany(x => x.Masraflar).OnDelete(DeleteBehavior.NoAction);
        });
    }

    public static void ConfigureMakbuz(this ModelBuilder builder)
    {
        builder.Entity<Makbuz>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Makbuzlar", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.MakbuzTuru).IsRequired().
            HasColumnType(SqlDbType.TinyInt.ToString());

            b.Property(x => x.MakbuzNo).IsRequired().
            HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(MakbuzConsts.MaxMakbuzNoLength);

            b.Property(x => x.Tarih).IsRequired().
           HasColumnType(SqlDbType.Date.ToString());

            b.Property(x => x.OzelKod1Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.OzelKod2Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.CariId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.KasaId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.BankaHesapId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.SubeId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.DonemId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            b.Property(x => x.HareketSayisi).IsRequired().
            HasColumnType(SqlDbType.Int.ToString());

            b.Property(x => x.CekToplamTutar).IsRequired().
            HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.SenetToplamTutar).IsRequired().
            HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.PosToplamTutar).IsRequired().
            HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.NakitToplamTutar).IsRequired().
            HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.BankaToplamTutar).IsRequired().
            HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.Durum).HasColumnType(SqlDbType.Bit.ToString());

            //indexes
            b.HasIndex(x => x.MakbuzNo);

            //relations
            b.HasOne(x => x.OzelKod1).WithMany(x => x.OzelKod1Makbuzlar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.OzelKod2).WithMany(x => x.OzelKod2Makbuzlar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Cari).WithMany(x => x.Makbuzlar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Kasa).WithMany(x => x.Makbuzlar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.BankaHesap).WithMany(x => x.Makbuzlar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Sube).WithMany(x => x.Makbuzlar).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Donem).WithMany(x => x.Makbuzlar).OnDelete(DeleteBehavior.NoAction);
        });
    }

    public static void ConfigureMakbuzHareket(this ModelBuilder builder)
    {
        builder.Entity<MakbuzHareket>(b =>
        {
            b.ToTable(OnMuhasebeConsts.DbTablePrefix + "MakbuzHareketler", OnMuhasebeConsts.DbSchema);
            b.ConfigureByConvention();

            //properties
            b.Property(x => x.MakbuzId).IsRequired().
            HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.OdemeTuru).IsRequired().
            HasColumnType(SqlDbType.TinyInt.ToString());

            b.Property(x => x.TakipNo).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(MakbuzHareketConsts.MaxTakipNoLength);

            b.Property(x => x.AsilBorclu).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(MakbuzHareketConsts.MaxAsilBorcluLength);

            b.Property(x => x.Ciranta).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(MakbuzHareketConsts.MaxCirantaLength);

            b.Property(x => x.BelgeNo).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(MakbuzHareketConsts.MaxBelgeNoLength);

            b.Property(x => x.CekHesapNo).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(MakbuzHareketConsts.MaxCekHesapNoLength);

            b.Property(x => x.CekBankaId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.CekBankaSubeId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.KasaId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.BankaHesapId).HasColumnType(SqlDbType.UniqueIdentifier.ToString());

            b.Property(x => x.Vade).HasColumnType(SqlDbType.Date.ToString());

            b.Property(x => x.BelgeDurumu).HasColumnType(SqlDbType.TinyInt.ToString());

            b.Property(x => x.Tutar).HasColumnType(SqlDbType.Money.ToString());

            b.Property(x => x.KendiBelgemiz).HasColumnType(SqlDbType.Bit.ToString());

            b.Property(x => x.Aciklama).HasColumnType(SqlDbType.VarChar.ToString()).
            HasMaxLength(EntityConsts.MaxAciklamaLength);

            //indexes
            b.HasIndex(x => x.TakipNo);

            //relations
            b.HasOne(x => x.Makbuz).WithMany(x => x.MakbuzHareketleri).OnDelete(DeleteBehavior.Cascade);

            b.HasOne(x => x.CekBanka).WithMany(x => x.MakbuzHareketleri).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.CekBankaSube).WithMany(x => x.MakbuzHareketleri).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.Kasa).WithMany(x => x.MakbuzHareketleri).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(x => x.BankaHesap).WithMany(x => x.MakbuzHareketler).OnDelete(DeleteBehavior.NoAction);
        });
    }
}