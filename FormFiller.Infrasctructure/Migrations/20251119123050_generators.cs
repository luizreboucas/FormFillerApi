using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormFiller.Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class generators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schemas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schemas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Generators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SchemaId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Generators_Schemas_SchemaId",
                        column: x => x.SchemaId,
                        principalTable: "Schemas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Param",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    GeneratorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Param", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Param_Generators_GeneratorId",
                        column: x => x.GeneratorId,
                        principalTable: "Generators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Generators_SchemaId",
                table: "Generators",
                column: "SchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Param_GeneratorId",
                table: "Param",
                column: "GeneratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Schemas_UserId",
                table: "Schemas",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Param");

            migrationBuilder.DropTable(
                name: "Generators");

            migrationBuilder.DropTable(
                name: "Schemas");
        }
    }
}
