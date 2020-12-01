using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.Features.Issues;
using ProjectManagementSystem.Features.Resources;
using System;

namespace ProjectManagementSystem.Features.ActionItems
{
    public class ActionItem
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateAssigned { get; set; }        
        public DateTime? ExpectedCompletionDate { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        public Status? status { get; set; }
        public string statusDescription { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? ResourceId { get; set; }
        public Guid? IssueId { get; set; }

        public ActionItem()
        {
            Id = Guid.NewGuid();
        }

        public static explicit operator Status(ActionItem v)
        {
            throw new NotImplementedException();
        }
    }

    internal class ActionItemEntityConfiguration : IEntityTypeConfiguration<ActionItem>
    {
        public void Configure(EntityTypeBuilder<ActionItem> actionItem)
        {
            actionItem.ToTable("ActionItem");

            actionItem.HasKey(x => x.Id);
            actionItem.Property(x => x.Name).IsRequired();
            actionItem.Property(x => x.Description);
            actionItem.Property(x => x.DateCreated);
            actionItem.Property(x => x.DateAssigned);            
            actionItem.Property(x => x.ExpectedCompletionDate);
            actionItem.Property(x => x.ActualCompletionDate);
            actionItem.Property(x => x.status);
            actionItem.Property(x => x.statusDescription);
            actionItem.Property(x => x.UpdateDate);

            actionItem.HasOne<Resource>().WithOne().HasForeignKey<ActionItem>(x => x.ResourceId).HasConstraintName("FK_Resource_AI");
            actionItem.HasOne<Issue>().WithOne().HasForeignKey<ActionItem>(x => x.IssueId).HasConstraintName("FK_Issue");
        }
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
