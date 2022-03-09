using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnkaYazilim.OnMuhasebe.Migrations
{
    public partial class mig_0008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirimFiyat",
                table: "AppMasraflar",
                newName: "SatisFiyat");

            migrationBuilder.RenameColumn(
                name: "KdvOrani",
                table: "AppHizmetler",
                newName: "KdvOran");

            migrationBuilder.RenameColumn(
                name: "BirimFiyat",
                table: "AppHizmetler",
                newName: "SatisFiyat");

            migrationBuilder.RenameColumn(
                name: "Fiyat",
                table: "AppFaturaHareketleri",
                newName: "SatisFiyat");

            migrationBuilder.AddColumn<decimal>(
                name: "AlisFiyat",
                table: "AppMasraflar",
                type: "Money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AlisFiyat",
                table: "AppHizmetler",
                type: "Money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "KdvTutar",
                table: "AppFaturaHareketleri",
                type: "Money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "Money",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "KdvOran",
                table: "AppFaturaHareketleri",
                type: "TinyInt",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "TinyInt",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IndirimTutar",
                table: "AppFaturaHareketleri",
                type: "Money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "Money",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "IndirimOran",
                table: "AppFaturaHareketleri",
                type: "TinyInt",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "TinyInt",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AlisFiyat",
                table: "AppFaturaHareketleri",
                type: "Money",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlisFiyat",
                table: "AppMasraflar");

            migrationBuilder.DropColumn(
                name: "AlisFiyat",
                table: "AppHizmetler");

            migrationBuilder.DropColumn(
                name: "AlisFiyat",
                table: "AppFaturaHareketleri");

            migrationBuilder.RenameColumn(
                name: "SatisFiyat",
                table: "AppMasraflar",
                newName: "BirimFiyat");

            migrationBuilder.RenameColumn(
                name: "SatisFiyat",
                table: "AppHizmetler",
                newName: "BirimFiyat");

            migrationBuilder.RenameColumn(
                name: "KdvOran",
                table: "AppHizmetler",
                newName: "KdvOrani");

            migrationBuilder.RenameColumn(
                name: "SatisFiyat",
                table: "AppFaturaHareketleri",
                newName: "Fiyat");

            migrationBuilder.AlterColumn<decimal>(
                name: "KdvTutar",
                table: "AppFaturaHareketleri",
                type: "Money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.AlterColumn<byte>(
                name: "KdvOran",
                table: "AppFaturaHareketleri",
                type: "TinyInt",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "TinyInt");

            migrationBuilder.AlterColumn<decimal>(
                name: "IndirimTutar",
                table: "AppFaturaHareketleri",
                type: "Money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.AlterColumn<byte>(
                name: "IndirimOran",
                table: "AppFaturaHareketleri",
                type: "TinyInt",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "TinyInt");
        }
    }
}
