using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassageApi_V1.Migrations
{
    /// <inheritdoc />
    public partial class fix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "massage",
                table: "Shift",
                newName: "MassageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shift_MassageTypeId",
                table: "Shift",
                column: "MassageTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shift_MassageType_MassageTypeId",
                table: "Shift",
                column: "MassageTypeId",
                principalTable: "MassageType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shift_MassageType_MassageTypeId",
                table: "Shift");

            migrationBuilder.DropIndex(
                name: "IX_Shift_MassageTypeId",
                table: "Shift");

            migrationBuilder.RenameColumn(
                name: "MassageTypeId",
                table: "Shift",
                newName: "massage");
        }
    }
}
