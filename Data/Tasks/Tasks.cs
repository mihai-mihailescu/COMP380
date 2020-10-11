using System;
using System.Collections.Generic;

namespace ProjectManagementSystem.Data.Tasks
{
    public class Tasks
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ResourceAssigned { get; set; }
        public DateTime? ExpectedStartDate { get; set; }
        public DateTime? ExpectedEndDate { get; set; }
        public int? ExpectedDuration { get; set; }
        public int? ExpectedEffort { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public int? ActualDuration { get; set; }
        public int? EffortCompleted { get; set; }
        public int? ActualEffort { get; set; }
        public decimal? PercentCompleted { get; set; }
        public List<string> PredecessorTasks { get; set; }
        public List<string> SuccessorTasks { get; set; }
        public List<string> ListOfIssues { get; set; }
        public TaskType TaskType { get; set; }
        public string ParentSummaryTask { get; set; }
        public List<string> GroupOtherTasks { get; set; }
    }

    public enum TaskType
    {
        Regular,
        Summary,
        Milestone
    }
}
