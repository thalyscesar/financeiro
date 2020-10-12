using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceiroNucleo.Migrations
{
    public partial class MinhaMigracaoDelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContasAPagar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    ValorOriginal = table.Column<decimal>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    DataPagamento = table.Column<DateTime>(nullable: false),
                    ValorMulta = table.Column<decimal>(nullable: false),
                    ValorJurosAoDia = table.Column<decimal>(nullable: false),
                    ValorCobrado = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasAPagar", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasAPagar");
        }
    }
}
