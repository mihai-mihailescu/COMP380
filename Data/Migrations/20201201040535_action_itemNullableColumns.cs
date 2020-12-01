using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementSystem.Migrations
{
    public partial class action_itemNullableColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue",
                table: "ActionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Resource_AI",
                table: "ActionItem");

            migrationBuilder.DropIndex(
                name: "IX_ActionItem_IssueId",
                table: "ActionItem");

            migrationBuilder.DropIndex(
                name: "IX_ActionItem_ResourceId",
                table: "ActionItem");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "ActionItem",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "ActionItem",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResourceId",
                table: "ActionItem",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IssueId",
                table: "ActionItem",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedCompletionDate",
                table: "ActionItem",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ActionItem",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAssigned",
                table: "ActionItem",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualCompletionDate",
                table: "ActionItem",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_ActionItem_IssueId",
                table: "ActionItem",
                column: "IssueId",
                unique: true,
                filter: "[IssueId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ActionItem_ResourceId",
                table: "ActionItem",
                column: "ResourceId",
                unique: true,
                filter: "[ResourceId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue",
                table: "ActionItem",
                column: "IssueId",
                principalTable: "Issue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_AI",
                table: "ActionItem",
                column: "ResourceId",
                principalTable: "Resource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue",
                table: "ActionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Resource_AI",
                table: "ActionItem");

            migrationBuilder.DropIndex(
                name: "IX_ActionItem_IssueId",
                table: "ActionItem");

            migrationBuilder.DropIndex(
                name: "IX_ActionItem_ResourceId",
                table: "ActionItem");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "ActionItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "ActionItem",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ResourceId",
                table: "ActionItem",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IssueId",
                table: "ActionItem",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedCompletionDate",
                table: "ActionItem",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ActionItem",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAssigned",
                table: "ActionItem",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualCompletionDate",
                table: "ActionItem",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActionItem_IssueId",
                table: "ActionItem",
                column: "IssueId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActionItem_ResourceId",
                table: "ActionItem",
                column: "ResourceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Issue",
                table: "ActionItem",
                column: "IssueId",
                principalTable: "Issue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_AI",
                table: "ActionItem",
                column: "ResourceId",
                principalTable: "Resource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
