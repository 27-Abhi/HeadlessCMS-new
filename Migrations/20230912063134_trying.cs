using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeadlessCMS.Migrations
{
    /// <inheritdoc />
    public partial class trying : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mediaJSON_VideoUrl",
                table: "Content",
                newName: "MediaJSON_VideoUrl");

            migrationBuilder.RenameColumn(
                name: "mediaJSON_Imageurl",
                table: "Content",
                newName: "MediaJSON_Imageurl");

            migrationBuilder.RenameColumn(
                name: "mediaJSON_AltText",
                table: "Content",
                newName: "MediaJSON_AltText");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MediaJSON_VideoUrl",
                table: "Content",
                newName: "mediaJSON_VideoUrl");

            migrationBuilder.RenameColumn(
                name: "MediaJSON_Imageurl",
                table: "Content",
                newName: "mediaJSON_Imageurl");

            migrationBuilder.RenameColumn(
                name: "MediaJSON_AltText",
                table: "Content",
                newName: "mediaJSON_AltText");
        }
    }
}
