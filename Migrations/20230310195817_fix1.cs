using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassageApi_V1.Migrations
{
    /// <inheritdoc />
    public partial class fix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "MassageType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MassageType_ShiftId",
                table: "MassageType",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_MassageType_Shift_ShiftId",
                table: "MassageType",
                column: "ShiftId",
                principalTable: "Shift",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MassageType_Shift_ShiftId",
                table: "MassageType");

            migrationBuilder.DropIndex(
                name: "IX_MassageType_ShiftId",
                table: "MassageType");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "MassageType");

            migrationBuilder.RenameColumn(
                name: "massage",
                table: "Shift",
                newName: "MassageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shift_MassageTypeId",
                table: "Shift",
                column: "MassageTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shift_MassageType_MassageTypeId",
                table: "Shift",
                column: "MassageTypeId",
                principalTable: "MassageType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
