using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Delete_the_mark : Migration
    {
        //Up 是升级数据库，，，Down是降级数据库
        //所以数据库不仅仅可以进行升级，还可以进行还原数据库的版本
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Book");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mark",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
