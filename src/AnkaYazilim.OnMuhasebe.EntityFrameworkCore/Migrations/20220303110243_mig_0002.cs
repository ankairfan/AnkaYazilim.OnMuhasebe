using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnkaYazilim.OnMuhasebe.Migrations
{
    public partial class mig_0002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IBAN",
                table: "AppBankaHesaplar",
                newName: "IbanNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IbanNo",
                table: "AppBankaHesaplar",
                newName: "IBAN");
        }
    }
}
