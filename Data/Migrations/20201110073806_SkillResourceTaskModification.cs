using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementSystem.Migrations
{
    public partial class SkillResourceTaskModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Resource_ResourceId",
                table: "Skill");

            migrationBuilder.DropTable(
                name: "TaskGroup");

            migrationBuilder.DropIndex(
                name: "IX_Skill_ResourceId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "ResourceId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "SkillLevel",
                table: "Skill");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentGroupTaskId",
                table: "Task",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skill",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ResourceSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ResourceId = table.Column<Guid>(nullable: false),
                    SkillId = table.Column<Guid>(nullable: false),
                    SkillLevel = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceSkill_Resource_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceSkill_SkillId",
                table: "ResourceSkill",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceSkill");

            migrationBuilder.DropColumn(
                name: "ParentGroupTaskId",
                table: "Task");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skill",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<Guid>(
                name: "ResourceId",
                table: "Skill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "SkillLevel",
                table: "Skill",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TaskGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssociatedTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskGroup_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skill_ResourceId",
                table: "Skill",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskGroup_TaskId",
                table: "TaskGroup",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Resource_ResourceId",
                table: "Skill",
                column: "ResourceId",
                principalTable: "Resource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
