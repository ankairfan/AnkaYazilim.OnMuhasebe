using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnkaYazilim.OnMuhasebe.Migrations
{
    public partial class mig_0004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "BirimFiyat",
                table: "AppMasraflar",
                type: "Money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "Money",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Barkod",
                table: "AppMasraflar",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barkod",
                table: "AppMasraflar");

            migrationBuilder.AlterColumn<decimal>(
                name: "BirimFiyat",
                table: "AppMasraflar",
                type: "Money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Money");
        }
    }
}
