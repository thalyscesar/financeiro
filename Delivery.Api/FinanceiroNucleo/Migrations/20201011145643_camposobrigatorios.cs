using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceiroNucleo.Migrations
{
    public partial class camposobrigatorios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorJurosAoDia",
                table: "ContasAPagar");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "ContasAPagar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorJuros",
                table: "ContasAPagar",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorJuros",
                table: "ContasAPagar");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "ContasAPagar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<decimal>(
                name: "ValorJurosAoDia",
                table: "ContasAPagar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
