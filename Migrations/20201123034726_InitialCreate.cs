using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Decision",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decision", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deliverable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Severity = table.Column<int>(nullable: false),
                    DateRaised = table.Column<DateTime>(nullable: false),
                    DateAssigned = table.Column<DateTime>(nullable: true),
                    ExpectedCompletionDate = table.Column<DateTime>(nullable: true),
                    ActualCompletionDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StatusDescription = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requirement",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    PayRate = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateAssigned = table.Column<DateTime>(nullable: false),
                    ExpectedCompletionDate = table.Column<DateTime>(nullable: false),
                    ActualCompletionDate = table.Column<DateTime>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    statusDescription = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    ResourceId = table.Column<Guid>(nullable: false),
                    IssueId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issue",
                        column: x => x.IssueId,
                        principalTable: "Issue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resource_AI",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailabilityCalendar",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ResourceId = table.Column<Guid>(nullable: false),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailabilityCalendar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailabilityCalendar_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TaskType = table.Column<string>(nullable: false),
                    ExpectedStartDate = table.Column<DateTime>(nullable: true),
                    ExpectedEndDate = table.Column<DateTime>(nullable: true),
                    ExpectedDuration = table.Column<string>(nullable: true),
                    ExpectedEffort = table.Column<int>(nullable: true),
                    ActualStartDate = table.Column<DateTime>(nullable: true),
                    ActualEndDate = table.Column<DateTime>(nullable: true),
                    ActualDuration = table.Column<string>(nullable: true),
                    EffortCompleted = table.Column<int>(nullable: true),
                    ActualEffort = table.Column<int>(nullable: true),
                    PercentCompleted = table.Column<string>(nullable: true),
                    ParentSummaryTaskId = table.Column<Guid>(nullable: true),
                    ParentGroupTaskId = table.Column<Guid>(nullable: true),
                    DeliverableId = table.Column<Guid>(nullable: true),
                    ResourceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliverable",
                        column: x => x.DeliverableId,
                        principalTable: "Deliverable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resource",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResourceSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ResourceId = table.Column<Guid>(nullable: false),
                    SkillId = table.Column<Guid>(nullable: false),
                    SkillLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskIssue",
                columns: table => new
                {
                    TaskId = table.Column<Guid>(nullable: false),
                    IssueId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskIssue", x => new { x.TaskId, x.IssueId });
                    table.ForeignKey(
                        name: "FK_TaskIssue_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskIssue_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskPredecessor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TaskId = table.Column<Guid>(nullable: false),
                    PredecessorTaskId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskPredecessor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskPredecessor_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskSuccessor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TaskId = table.Column<Guid>(nullable: false),
                    SuccessorTaskId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSuccessor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskSuccessor_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AvailabilityCalendar_ResourceId",
                table: "AvailabilityCalendar",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceSkill_SkillId",
                table: "ResourceSkill",
                column: "SkillId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_DeliverableId",
                table: "Task",
                column: "DeliverableId",
                unique: true,
                filter: "[DeliverableId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ResourceId",
                table: "Task",
                column: "ResourceId",
                unique: true,
                filter: "[ResourceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TaskIssue_IssueId",
                table: "TaskIssue",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskPredecessor_TaskId",
                table: "TaskPredecessor",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSuccessor_TaskId",
                table: "TaskSuccessor",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionItem");

            migrationBuilder.DropTable(
                name: "AvailabilityCalendar");

            migrationBuilder.DropTable(
                name: "Decision");

            migrationBuilder.DropTable(
                name: "Requirement");

            migrationBuilder.DropTable(
                name: "ResourceSkill");

            migrationBuilder.DropTable(
                name: "TaskIssue");

            migrationBuilder.DropTable(
                name: "TaskPredecessor");

            migrationBuilder.DropTable(
                name: "TaskSuccessor");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Issue");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Deliverable");

            migrationBuilder.DropTable(
                name: "Resource");
        }
    }
}
