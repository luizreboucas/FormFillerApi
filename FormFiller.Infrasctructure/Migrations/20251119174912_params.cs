using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormFiller.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class @params : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Param_Generators_GeneratorId",
                table: "Param");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Param",
                table: "Param");

            migrationBuilder.RenameTable(
                name: "Param",
                newName: "Params");

            migrationBuilder.RenameIndex(
                name: "IX_Param_GeneratorId",
                table: "Params",
                newName: "IX_Params_GeneratorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Params",
                table: "Params",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Params_Generators_GeneratorId",
                table: "Params",
                column: "GeneratorId",
                principalTable: "Generators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Params_Generators_GeneratorId",
                table: "Params");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Params",
                table: "Params");

            migrationBuilder.RenameTable(
                name: "Params",
                newName: "Param");

            migrationBuilder.RenameIndex(
                name: "IX_Params_GeneratorId",
                table: "Param",
                newName: "IX_Param_GeneratorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Param",
                table: "Param",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Param_Generators_GeneratorId",
                table: "Param",
                column: "GeneratorId",
                principalTable: "Generators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
