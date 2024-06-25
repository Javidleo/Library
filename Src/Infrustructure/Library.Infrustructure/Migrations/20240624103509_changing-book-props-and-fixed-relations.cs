using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class changingbookpropsandfixedrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Admins_AdminId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AdminId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AdminId",
                table: "Books",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Admins_AdminId",
                table: "Books",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
