using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeadlessCMS.Migrations
{
    /// <inheritdoc />
    public partial class media : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaJSON_AltText",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "MediaJSON_Imageurl",
                table: "Content");

            migrationBuilder.RenameColumn(
                name: "MediaJSON_VideoUrl",
                table: "Content",
                newName: "MediaJSON");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MediaJSON",
                table: "Content",
                newName: "MediaJSON_VideoUrl");

            migrationBuilder.AddColumn<string>(
                name: "MediaJSON_AltText",
                table: "Content",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MediaJSON_Imageurl",
                table: "Content",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
