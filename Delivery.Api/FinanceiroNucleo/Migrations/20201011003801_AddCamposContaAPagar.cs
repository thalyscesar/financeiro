using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceiroNucleo.Migrations
{
    public partial class AddCamposContaAPagar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiasEmAtraso",
                table: "ContasAPagar",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiasEmAtraso",
                table: "ContasAPagar");
        }
    }
}
