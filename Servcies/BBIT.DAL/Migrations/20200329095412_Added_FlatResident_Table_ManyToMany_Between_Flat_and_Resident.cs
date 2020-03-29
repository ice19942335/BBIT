using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BBIT.DAL.Migrations
{
    public partial class Added_FlatResident_Table_ManyToMany_Between_Flat_and_Resident : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlatResidents",
                columns: table => new
                {
                    FlatId = table.Column<Guid>(nullable: false),
                    ResidentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlatResidents", x => new { x.FlatId, x.ResidentId });
                    table.ForeignKey(
                        name: "FK_FlatResidents_Flats_FlatId",
                        column: x => x.FlatId,
                        principalTable: "Flats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlatResidents_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlatResidents_ResidentId",
                table: "FlatResidents",
                column: "ResidentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlatResidents");
        }
    }
}
