using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.Features.Deliverables;
using ProjectManagementSystem.Features.Resources;
using ProjectManagementSystem.Features.Shared;
using System;
using System.Collections.ObjectModel;

namespace ProjectManagementSystem.Features.Tasks
{
    public class Task
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskType TaskType { get; set; }
        public DateTime? ExpectedStartDate { get; set; }
        public DateTime? ExpectedEndDate { get; set; }
        public string ExpectedDuration { get; set; }
        public int? ExpectedEffort { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public string ActualDuration { get; set; }
        public int? EffortCompleted { get; set; }
        public int? ActualEffort { get; set; }
        public string PercentCompleted { get; set; }
        public Guid? ParentSummaryTaskId { get; set; }
        public Guid? ParentGroupTaskId { get; set; }
        public Collection<TaskPredecessor> TaskPredecessor { get; set; } = new Collection<TaskPredecessor>();
        public Collection<TaskSuccessor> TaskSuccessor { get; set; } = new Collection<TaskSuccessor>();                
        public Collection<TaskIssue> TaskIssue { get; set; } = new Collection<TaskIssue>();
        public Guid? DeliverableId { get; set; }
        public Guid? ResourceId { get; set; }

        public Task()
        {
            Id = Guid.NewGuid();
        }
    }

    internal class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> task)
        {
            task.ToTable("Task");

            task.HasKey(x => x.Id);
            task.Property(x => x.Name).IsRequired();
            task.Property(x => x.Description);
            task.Property(x => x.TaskType).HasConversion<string>();
            task.Property(x => x.ExpectedStartDate);
            task.Property(x => x.ExpectedEndDate);
            task.Property(x => x.ExpectedDuration);
            task.Property(x => x.ExpectedEffort);
            task.Property(x => x.ActualStartDate);
            task.Property(x => x.ActualEndDate);
            task.Property(x => x.ActualDuration);
            task.Property(x => x.EffortCompleted);
            task.Property(x => x.ActualEffort);
            task.Property(x => x.PercentCompleted);
            task.Property(x => x.ParentSummaryTaskId);            
            task.HasOne<Deliverable>().WithMany().HasForeignKey(x => x.DeliverableId).HasConstraintName("FK_Deliverable");
            task.HasOne<Resource>().WithOne().HasForeignKey<Task>(x => x.ResourceId).HasConstraintName("FK_Resource");
            task.Property(x => x.ParentGroupTaskId);

            task.OwnsMany(x => x.TaskPredecessor, tp =>
            {
                tp.ToTable("TaskPredecessor");
                tp.HasKey(x => x.Id);
                tp.WithOwner().HasForeignKey(x => x.TaskId);
                tp.Property(x => x.PredecessorTaskId);
            });

            task.OwnsMany(x => x.TaskSuccessor, ts =>
            {
                ts.ToTable("TaskSuccessor");
                ts.HasKey(x => x.Id);
                ts.WithOwner().HasForeignKey(x => x.TaskId);
                ts.Property(x => x.SuccessorTaskId);
            });
        }
    }

    public class TaskPredecessor
    {        
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid PredecessorTaskId { get; set; }        
    }

    public class TaskSuccessor
    {       
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid SuccessorTaskId { get; set; }        
    }    

    public enum TaskType
    {
        Regular,
        Summary,
        Milestone
    }

    public enum PredecessorSuccessorType
    {
        Predecessor,
        Successor
    }
}
