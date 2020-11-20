using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.Features.Shared;
using System;
using System.Collections.ObjectModel;

namespace ProjectManagementSystem.Features.Issues
{
    public class Issue
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Severity Severity { get; set; }
        public DateTime DateRaised { get; set; }
        public DateTime? DateAssigned { get; set; }
        public DateTime? ExpectedCompletionDate { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        public Status Status { get; set; }
        public string StatusDescription { get; set; }
        public DateTime UpdateDate { get; set; }        
        public Collection<TaskIssue> TaskIssue { get; set; }

        public Issue()
        {
            Id = Guid.NewGuid();
            DateRaised = DateTime.Now;
        }
    }

    internal class IssueEntityConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> issue)
        {
            issue.ToTable("Issue");

            issue.HasKey(x => x.Id);
            issue.Property(x => x.Name).IsRequired();
            issue.Property(x => x.Description);
            issue.Property(x => x.Priority);
            issue.Property(x => x.Severity);
            issue.Property(x => x.DateRaised);
            issue.Property(x => x.DateAssigned);
            issue.Property(x => x.ExpectedCompletionDate);
            issue.Property(x => x.ActualCompletionDate);
            issue.Property(x => x.Status);
            issue.Property(x => x.StatusDescription);
            issue.Property(x => x.UpdateDate);
        }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public enum Severity
    {
        Minor,
        Low,
        Medium,
        High,
        Critical
    }

    public enum Status
    {
        Open,
        Closed,
        InProgress,
        Hold,
        Complete
    }
}
