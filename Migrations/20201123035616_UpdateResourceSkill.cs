using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementSystem.Migrations
{
    public partial class UpdateResourceSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceSkill",
                table: "ResourceSkill");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceId",
                table: "ResourceSkill",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceSkill",
                table: "ResourceSkill",
                column: "Id")
                .Annotation("SqlServer:Clustered", false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceSkill",
                table: "ResourceSkill");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResourceId",
                table: "ResourceSkill",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceSkill",
                table: "ResourceSkill",
                column: "Id");
        }
    }
}
