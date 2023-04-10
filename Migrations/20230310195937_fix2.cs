using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassageApi_V1.Migrations
{
    /// <inheritdoc />
    public partial class fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
