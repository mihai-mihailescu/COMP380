using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementSystem.Migrations
{
    public partial class FixedDeliverableForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Task_DeliverableId",
                table: "Task");

            migrationBuilder.CreateIndex(
                name: "IX_Task_DeliverableId",
                table: "Task",
                column: "DeliverableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Task_DeliverableId",
                table: "Task");

            migrationBuilder.CreateIndex(
                name: "IX_Task_DeliverableId",
                table: "Task",
                column: "DeliverableId",
                unique: true,
                filter: "[DeliverableId] IS NOT NULL");
        }
    }
}
