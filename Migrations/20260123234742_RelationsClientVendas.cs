using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crediarioW.Migrations
{
    /// <inheritdoc />
    public partial class RelationsClientVendas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clients_ClienteId",
                table: "Vendas");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clients_ClienteId",
                table: "Vendas",
                column: "ClienteId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clients_ClienteId",
                table: "Vendas");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clients_ClienteId",
                table: "Vendas",
                column: "ClienteId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
