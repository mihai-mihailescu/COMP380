using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.Features.Issues;
using ProjectManagementSystem.Features.Tasks;
using System;
using System.Collections.ObjectModel;

namespace ProjectManagementSystem.Features.Shared
{
    public class TaskIssue
    {   
        public Guid TaskId { get; set; }
        public Task Task { get; set; }
        public Guid IssueId { get; set; }
        public Issue Issue { get; set; }
    }

    internal class TaskIssueEntityConfiguration : IEntityTypeConfiguration<TaskIssue>
    {
        public void Configure(EntityTypeBuilder<TaskIssue> taskIssue)
        {
            taskIssue.HasKey(x => new { x.TaskId, x.IssueId });

            taskIssue.HasOne(x => x.Issue).WithMany(x => x.TaskIssue).HasForeignKey(x => x.IssueId);
            taskIssue.HasOne(x => x.Task).WithMany(x => x.TaskIssue).HasForeignKey(x => x.TaskId); 
        }
    }
}
