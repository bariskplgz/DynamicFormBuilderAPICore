using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicFormBuilder.Repository.Migrations
{
    public partial class fieldchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Field_Forms_FormId",
                table: "Field");

            migrationBuilder.AlterColumn<int>(
                name: "FormId",
                table: "Field",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Field_Forms_FormId",
                table: "Field",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Field_Forms_FormId",
                table: "Field");

            migrationBuilder.AlterColumn<int>(
                name: "FormId",
                table: "Field",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Field_Forms_FormId",
                table: "Field",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id");
        }
    }
}
