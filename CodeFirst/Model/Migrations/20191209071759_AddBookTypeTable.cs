using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class AddBookTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookTypeId",
                table: "Book",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookTypeId",
                table: "Book",
                column: "BookTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookType_BookTypeId",
                table: "Book",
                column: "BookTypeId",
                principalTable: "BookType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookType_BookTypeId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "BookType");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookTypeId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookTypeId",
                table: "Book");
        }
    }
}
