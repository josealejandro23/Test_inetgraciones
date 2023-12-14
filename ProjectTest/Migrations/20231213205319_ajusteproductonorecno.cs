using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_jvarg361.Migrations
{
    /// <inheritdoc />
    public partial class ajusteproductonorecno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "recno",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "recno",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
