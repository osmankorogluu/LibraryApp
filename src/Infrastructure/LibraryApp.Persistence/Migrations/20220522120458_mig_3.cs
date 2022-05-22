using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryApp.Persistence.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookImageId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BookId",
                table: "BookImages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookImageId",
                table: "Books",
                column: "BookImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookImages_BookImageId",
                table: "Books",
                column: "BookImageId",
                principalTable: "BookImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookImages_BookImageId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookImageId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookImageId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "BookImages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
