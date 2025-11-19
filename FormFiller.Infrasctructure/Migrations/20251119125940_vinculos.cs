using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormFiller.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class vinculos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Generators_Schemas_SchemaId",
                table: "Generators");

            migrationBuilder.DropIndex(
                name: "IX_Generators_SchemaId",
                table: "Generators");

            migrationBuilder.DropColumn(
                name: "SchemaId",
                table: "Generators");

            migrationBuilder.CreateTable(
                name: "GeneratorSchema",
                columns: table => new
                {
                    GeneratorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    SchemasId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratorSchema", x => new { x.GeneratorsId, x.SchemasId });
                    table.ForeignKey(
                        name: "FK_GeneratorSchema_Generators_GeneratorsId",
                        column: x => x.GeneratorsId,
                        principalTable: "Generators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneratorSchema_Schemas_SchemasId",
                        column: x => x.SchemasId,
                        principalTable: "Schemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneratorSchema_SchemasId",
                table: "GeneratorSchema",
                column: "SchemasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneratorSchema");

            migrationBuilder.AddColumn<Guid>(
                name: "SchemaId",
                table: "Generators",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Generators_SchemaId",
                table: "Generators",
                column: "SchemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Generators_Schemas_SchemaId",
                table: "Generators",
                column: "SchemaId",
                principalTable: "Schemas",
                principalColumn: "Id");
        }
    }
}
