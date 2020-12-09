using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementSystem.Migrations
{
    public partial class AddDecsionFKtoIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DecisionId",
                table: "Issue",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "ActionItem",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Issue_DecisionId",
                table: "Issue",
                column: "DecisionId",
                unique: true,
                filter: "[DecisionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Decision_DecisionId",
                table: "Issue",
                column: "DecisionId",
                principalTable: "Decision",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Decision_DecisionId",
                table: "Issue");

            migrationBuilder.DropIndex(
                name: "IX_Issue_DecisionId",
                table: "Issue");

            migrationBuilder.DropColumn(
                name: "DecisionId",
                table: "Issue");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "ActionItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
