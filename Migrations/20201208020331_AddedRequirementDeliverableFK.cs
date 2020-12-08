using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementSystem.Migrations
{
    public partial class AddedRequirementDeliverableFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeliverableId",
                table: "Requirement",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_DeliverableId",
                table: "Requirement",
                column: "DeliverableId",
                unique: true,
                filter: "[DeliverableId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Requirement_Deliverable_DeliverableId",
                table: "Requirement",
                column: "DeliverableId",
                principalTable: "Deliverable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requirement_Deliverable_DeliverableId",
                table: "Requirement");

            migrationBuilder.DropIndex(
                name: "IX_Requirement_DeliverableId",
                table: "Requirement");

            migrationBuilder.DropColumn(
                name: "DeliverableId",
                table: "Requirement");
        }
    }
}
