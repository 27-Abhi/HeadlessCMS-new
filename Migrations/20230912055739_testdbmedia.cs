using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeadlessCMS.Migrations
{
    /// <inheritdoc />
    public partial class testdbmedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created",
                table: "Page");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Content",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Content",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "pahId",
                table: "Content",
                newName: "Component_id");

            migrationBuilder.RenameColumn(
                name: "mediaJSON",
                table: "Content",
                newName: "mediaJSON_VideoUrl");

            migrationBuilder.RenameColumn(
                name: "componentName",
                table: "Content",
                newName: "mediaJSON_Imageurl");

            migrationBuilder.RenameColumn(
                name: "componentID",
                table: "Components",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "CreatedOn",
                table: "Page",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Content",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "mediaJSON_AltText",
                table: "Content",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "mediaJSON_AltText",
                table: "Content");

            migrationBuilder.RenameColumn(
                name: "Title",  
                table: "Content",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Content",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "mediaJSON_VideoUrl",
                table: "Content",
                newName: "mediaJSON");

            migrationBuilder.RenameColumn(
                name: "mediaJSON_Imageurl",
                table: "Content",
                newName: "componentName");

            migrationBuilder.RenameColumn(
                name: "Component_id",
                table: "Content",
                newName: "pahId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Components",
                newName: "componentID");

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Page",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
