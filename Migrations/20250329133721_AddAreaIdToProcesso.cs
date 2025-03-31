using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace case_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddAreaIdToProcesso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AreaId",
                table: "Processos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Processos_AreaId",
                table: "Processos",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processos_Areas_AreaId",
                table: "Processos",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processos_Areas_AreaId",
                table: "Processos");

            migrationBuilder.DropIndex(
                name: "IX_Processos_AreaId",
                table: "Processos");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Processos");
        }
    }
}
