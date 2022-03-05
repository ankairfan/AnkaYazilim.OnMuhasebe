using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnkaYazilim.OnMuhasebe.Migrations
{
    public partial class mig_0005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SatisFiyat",
                table: "AppStoklar",
                type: "Money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "Money",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "KdvOran",
                table: "AppStoklar",
                type: "TinyInt",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "TinyInt",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AlisFiyat",
                table: "AppStoklar",
                type: "Money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "Money",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SatisFiyat",
                table: "AppStoklar",
                type: "Money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.AlterColumn<byte>(
                name: "KdvOran",
                table: "AppStoklar",
                type: "TinyInt",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "TinyInt");

            migrationBuilder.AlterColumn<decimal>(
                name: "AlisFiyat",
                table: "AppStoklar",
                type: "Money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Money");
        }
    }
}
