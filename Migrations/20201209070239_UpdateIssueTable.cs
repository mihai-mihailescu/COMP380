using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementSystem.Migrations
{
    public partial class UpdateIssueTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DecisionId",
                table: "Issue",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
