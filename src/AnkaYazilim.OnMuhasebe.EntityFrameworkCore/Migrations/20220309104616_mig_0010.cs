using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnkaYazilim.OnMuhasebe.Migrations
{
    public partial class mig_0010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "KdvOran",
                table: "AppFaturaHareketleri",
                type: "TinyInt",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "TinyInt",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "KdvOran",
                table: "AppFaturaHareketleri",
                type: "TinyInt",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "TinyInt");
        }
    }
}
