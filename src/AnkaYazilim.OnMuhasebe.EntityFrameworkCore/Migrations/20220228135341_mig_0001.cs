using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnkaYazilim.OnMuhasebe.Migrations
{
    public partial class mig_0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFaturaHareketleri_AppFAturalar_FaturaId",
                table: "AppFaturaHareketleri");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFAturalar_AppCariler_CariId",
                table: "AppFAturalar");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFAturalar_AppDonemler_DonemId",
                table: "AppFAturalar");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFAturalar_AppOzelKodlar_OzelKod1Id",
                table: "AppFAturalar");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFAturalar_AppOzelKodlar_OzelKod2Id",
                table: "AppFAturalar");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFAturalar_AppSubeler_SubeId",
                table: "AppFAturalar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppFAturalar",
                table: "AppFAturalar");

            migrationBuilder.RenameTable(
                name: "AppFAturalar",
                newName: "AppFaturalar");

            migrationBuilder.RenameIndex(
                name: "IX_AppFAturalar_SubeId",
                table: "AppFaturalar",
                newName: "IX_AppFaturalar_SubeId");

            migrationBuilder.RenameIndex(
                name: "IX_AppFAturalar_OzelKod2Id",
                table: "AppFaturalar",
                newName: "IX_AppFaturalar_OzelKod2Id");

            migrationBuilder.RenameIndex(
                name: "IX_AppFAturalar_OzelKod1Id",
                table: "AppFaturalar",
                newName: "IX_AppFaturalar_OzelKod1Id");

            migrationBuilder.RenameIndex(
                name: "IX_AppFAturalar_FaturaNo",
                table: "AppFaturalar",
                newName: "IX_AppFaturalar_FaturaNo");

            migrationBuilder.RenameIndex(
                name: "IX_AppFAturalar_DonemId",
                table: "AppFaturalar",
                newName: "IX_AppFaturalar_DonemId");

            migrationBuilder.RenameIndex(
                name: "IX_AppFAturalar_CariId",
                table: "AppFaturalar",
                newName: "IX_AppFaturalar_CariId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppFaturalar",
                table: "AppFaturalar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFaturaHareketleri_AppFaturalar_FaturaId",
                table: "AppFaturaHareketleri",
                column: "FaturaId",
                principalTable: "AppFaturalar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFaturalar_AppCariler_CariId",
                table: "AppFaturalar",
                column: "CariId",
                principalTable: "AppCariler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFaturalar_AppDonemler_DonemId",
                table: "AppFaturalar",
                column: "DonemId",
                principalTable: "AppDonemler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFaturalar_AppOzelKodlar_OzelKod1Id",
                table: "AppFaturalar",
                column: "OzelKod1Id",
                principalTable: "AppOzelKodlar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFaturalar_AppOzelKodlar_OzelKod2Id",
                table: "AppFaturalar",
                column: "OzelKod2Id",
                principalTable: "AppOzelKodlar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFaturalar_AppSubeler_SubeId",
                table: "AppFaturalar",
                column: "SubeId",
                principalTable: "AppSubeler",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFaturaHareketleri_AppFaturalar_FaturaId",
                table: "AppFaturaHareketleri");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFaturalar_AppCariler_CariId",
                table: "AppFaturalar");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFaturalar_AppDonemler_DonemId",
                table: "AppFaturalar");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFaturalar_AppOzelKodlar_OzelKod1Id",
                table: "AppFaturalar");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFaturalar_AppOzelKodlar_OzelKod2Id",
                table: "AppFaturalar");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFaturalar_AppSubeler_SubeId",
                table: "AppFaturalar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppFaturalar",
                table: "AppFaturalar");

            migrationBuilder.RenameTable(
                name: "AppFaturalar",
                newName: "AppFAturalar");

            migrationBuilder.RenameIndex(
                name: "IX_AppFaturalar_SubeId",
                table: "AppFAturalar",
                newName: "IX_AppFAturalar_SubeId");

            migrationBuilder.RenameIndex(
                name: "IX_AppFaturalar_OzelKod2Id",
                table: "AppFAturalar",
                newName: "IX_AppFAturalar_OzelKod2Id");

            migrationBuilder.RenameIndex(
                name: "IX_AppFaturalar_OzelKod1Id",
                table: "AppFAturalar",
                newName: "IX_AppFAturalar_OzelKod1Id");

            migrationBuilder.RenameIndex(
                name: "IX_AppFaturalar_FaturaNo",
                table: "AppFAturalar",
                newName: "IX_AppFAturalar_FaturaNo");

            migrationBuilder.RenameIndex(
                name: "IX_AppFaturalar_DonemId",
                table: "AppFAturalar",
                newName: "IX_AppFAturalar_DonemId");

            migrationBuilder.RenameIndex(
                name: "IX_AppFaturalar_CariId",
                table: "AppFAturalar",
                newName: "IX_AppFAturalar_CariId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppFAturalar",
                table: "AppFAturalar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFaturaHareketleri_AppFAturalar_FaturaId",
                table: "AppFaturaHareketleri",
                column: "FaturaId",
                principalTable: "AppFAturalar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFAturalar_AppCariler_CariId",
                table: "AppFAturalar",
                column: "CariId",
                principalTable: "AppCariler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFAturalar_AppDonemler_DonemId",
                table: "AppFAturalar",
                column: "DonemId",
                principalTable: "AppDonemler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFAturalar_AppOzelKodlar_OzelKod1Id",
                table: "AppFAturalar",
                column: "OzelKod1Id",
                principalTable: "AppOzelKodlar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFAturalar_AppOzelKodlar_OzelKod2Id",
                table: "AppFAturalar",
                column: "OzelKod2Id",
                principalTable: "AppOzelKodlar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFAturalar_AppSubeler_SubeId",
                table: "AppFAturalar",
                column: "SubeId",
                principalTable: "AppSubeler",
                principalColumn: "Id");
        }
    }
}
