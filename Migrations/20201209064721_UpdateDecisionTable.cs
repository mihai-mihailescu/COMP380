using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementSystem.Migrations
{
    public partial class UpdateDecisionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue",
                table: "ActionItem");

            migrationBuilder.DropIndex(
                name: "IX_ActionItem_IssueId",
                table: "ActionItem");

            migrationBuilder.AddColumn<Guid>(
                name: "IssueId",
                table: "Decision",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Decision_IssueId",
                table: "Decision",
                column: "IssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Decision_Issue_IssueId",
                table: "Decision",
                column: "IssueId",
                principalTable: "Issue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Decision_Issue_IssueId",
                table: "Decision");

            migrationBuilder.DropIndex(
                name: "IX_Decision_IssueId",
                table: "Decision");

            migrationBuilder.DropColumn(
                name: "IssueId",
                table: "Decision");

            migrationBuilder.CreateIndex(
                name: "IX_ActionItem_IssueId",
                table: "ActionItem",
                column: "IssueId",
                unique: true,
                filter: "[IssueId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue",
                table: "ActionItem",
                column: "IssueId",
                principalTable: "Issue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
