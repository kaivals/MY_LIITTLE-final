using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mylittle_project.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TenentPortalLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourcePortalId = table.Column<int>(type: "int", nullable: false),
                    TargetPortalId = table.Column<int>(type: "int", nullable: false),
                    LinkType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedSince = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenentPortalLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenentPortalLinks_Portals_SourcePortalId",
                        column: x => x.SourcePortalId,
                        principalTable: "Portals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TenentPortalLinks_Portals_TargetPortalId",
                        column: x => x.TargetPortalId,
                        principalTable: "Portals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenentPortalLinks_SourcePortalId",
                table: "TenentPortalLinks",
                column: "SourcePortalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenentPortalLinks_TargetPortalId",
                table: "TenentPortalLinks",
                column: "TargetPortalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenentPortalLinks");
        }
    }
}
