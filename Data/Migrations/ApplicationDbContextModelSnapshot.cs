﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManagementSystem.Data;

namespace ProjectManagementSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectManagementSystem.Features.ActionItems.ActionItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ActualCompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateAssigned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpectedCompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("IssueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("status")
                        .HasColumnType("int");

                    b.Property<string>("statusDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IssueId")
                        .IsUnique()
                        .HasFilter("[IssueId] IS NOT NULL");

                    b.HasIndex("ResourceId")
                        .IsUnique()
                        .HasFilter("[ResourceId] IS NOT NULL");

                    b.ToTable("ActionItem");
                });

            modelBuilder.Entity("ProjectManagementSystem.Features.Decision.Decision", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Decision");
                });

            modelBuilder.Entity("ProjectManagementSystem.Features.Deliverables.Deliverable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Deliverable");
                });

            modelBuilder.Entity("ProjectManagementSystem.Features.Issues.Issue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ActualCompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateAssigned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRaised")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpectedCompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("Severity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StatusDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Issue");
                });

            modelBuilder.Entity("ProjectManagementSystem.Features.Requirements.Requirement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Requirement");
                });

            modelBuilder.Entity("ProjectManagementSystem.Features.Resources.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PayRate")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("ProjectManagementSystem.Features.Shared.TaskIssue", b =>
                {
                    b.Property<Guid>("TaskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IssueId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TaskId", "IssueId");

                    b.HasIndex("IssueId");

                    b.ToTable("TaskIssue");
                });

            modelBuilder.Entity("ProjectManagementSystem.Features.Skills.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("ProjectManagementSystem.Features.Tasks.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActualDuration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ActualEffort")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ActualEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ActualStartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeliverableId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EffortCompleted")
                        .HasColumnType("int");

                    b.Property<string>("ExpectedDuration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExpectedEffort")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ExpectedEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpectedStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentGroupTaskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ParentSummaryTaskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PercentCompleted")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TaskType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeliverableId")
                        .IsUnique()
                        .HasFilter("[DeliverableId] IS NOT NULL");

                    b.HasIndex("ResourceId")
                        .IsUnique()
                        .HasFilter("[ResourceId] IS NOT NULL");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("ProjectManagementSystem.Features.ActionItems.ActionItem", b =>
                {
                    b.HasOne("ProjectManagementSystem.Features.Issues.Issue", null)
                        .WithOne()
                        .HasForeignKey("ProjectManagementSystem.Features.ActionItems.ActionItem", "IssueId")
                        .HasConstraintName("FK_Issue");

                    b.HasOne("ProjectManagementSystem.Features.Resources.Resource", null)
                        .WithOne()
                        .HasForeignKey("ProjectManagementSystem.Features.ActionItems.ActionItem", "ResourceId")
                        .HasConstraintName("FK_Resource_AI");
                });

            modelBuilder.Entity("ProjectManagementSystem.Features.Resources.Resource", b =>
                {
                    b.OwnsMany("ProjectManagementSystem.Features.Resources.AvailabilityCalendar", "AvailabilityCalendar", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("From")
                                .HasColumnType("datetime2");

                            b1.Property<Guid>("ResourceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("To")
                                .HasColumnType("datetime2");

                            b1.HasKey("Id");

                            b1.HasIndex("ResourceId");

                            b1.ToTable("AvailabilityCalendar");

                            b1.WithOwner()
                                .HasForeignKey("ResourceId");
                        });

                    b.OwnsMany("ProjectManagementSystem.Features.Resources.ResourceSkill", "ResourceSkill", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("ResourceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("SkillId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("SkillLevel")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id");

                            b1.HasIndex("SkillId");

                            b1.ToTable("ResourceSkill");

                            b1.WithOwner()
                                .HasForeignKey("SkillId");
                        });
                });

            modelBuilder.Entity("ProjectManagementSystem.Features.Shared.TaskIssue", b =>
                {
                    b.HasOne("ProjectManagementSystem.Features.Issues.Issue", "Issue")
                        .WithMany("TaskIssue")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagementSystem.Features.Tasks.Task", "Task")
                        .WithMany("TaskIssue")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectManagementSystem.Features.Tasks.Task", b =>
                {
                    b.HasOne("ProjectManagementSystem.Features.Deliverables.Deliverable", null)
                        .WithOne()
                        .HasForeignKey("ProjectManagementSystem.Features.Tasks.Task", "DeliverableId")
                        .HasConstraintName("FK_Deliverable");

                    b.HasOne("ProjectManagementSystem.Features.Resources.Resource", null)
                        .WithOne()
                        .HasForeignKey("ProjectManagementSystem.Features.Tasks.Task", "ResourceId")
                        .HasConstraintName("FK_Resource");

                    b.OwnsMany("ProjectManagementSystem.Features.Tasks.TaskPredecessor", "TaskPredecessor", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("PredecessorTaskId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("TaskId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("TaskId");

                            b1.ToTable("TaskPredecessor");

                            b1.WithOwner()
                                .HasForeignKey("TaskId");
                        });

                    b.OwnsMany("ProjectManagementSystem.Features.Tasks.TaskSuccessor", "TaskSuccessor", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("SuccessorTaskId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("TaskId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("TaskId");

                            b1.ToTable("TaskSuccessor");

                            b1.WithOwner()
                                .HasForeignKey("TaskId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
