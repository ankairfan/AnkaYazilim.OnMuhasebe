using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnkaYazilim.OnMuhasebe.Migrations
{
    public partial class mig_0011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OdemeBelgesi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MakbuzId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdemeTuru = table.Column<byte>(type: "tinyint", nullable: false),
                    TakipNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CekBankaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CekBankaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CekBankaSubeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CekBankaSubeAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CekHesapNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BelgeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AsilBorclu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciranta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankaHesapId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankaHesapAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BelgeDurumu = table.Column<byte>(type: "tinyint", nullable: false),
                    KendiBelgemiz = table.Column<bool>(type: "bit", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdemeBelgesi", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdemeBelgesi");
        }
    }
}
