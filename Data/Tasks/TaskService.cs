using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Data.Tasks
{
    public class TaskService
    {
        private static readonly Tasks[] SeedTasks = new[]
        {
            new Tasks() {Id = Guid.NewGuid(), Name = "Write user stories", Description = "This task does some stuff in regards to the writing user stories", ResourceAssigned = "Mihai", ExpectedStartDate = DateTime.Now.AddDays(1), ExpectedEndDate = DateTime.Now.AddDays(3), 
                ExpectedDuration="2 days", ExpectedEffort=2, ActualStartDate = null, ActualEndDate = null, ActualDuration= null, EffortCompleted = null, ActualEffort = null, PercentCompleted = null, PredecessorTasks = new List<string>(), 
                SuccessorTasks = new List<string>(), ListOfIssues = new List<string>(), TaskType=TaskType.Regular, ParentSummaryTask = string.Empty, GroupOtherTasks = new List<string>() },
            new Tasks() {Id = Guid.NewGuid(), Name = "Create high level design", Description = "This task does some stuff in regards to creating high level design", ResourceAssigned = "Richard", ExpectedStartDate = DateTime.Now.AddDays(2), ExpectedEndDate = DateTime.Now.AddDays(3),
                ExpectedDuration="2 days", ExpectedEffort=2, ActualStartDate = null, ActualEndDate = null, ActualDuration= null, EffortCompleted = null, ActualEffort = null, PercentCompleted = null, PredecessorTasks = new List<string>(),
                SuccessorTasks = new List<string>(), ListOfIssues = new List<string>(), TaskType=TaskType.Summary, ParentSummaryTask = string.Empty, GroupOtherTasks = new List<string>() },
            new Tasks() {Id = Guid.NewGuid(), Name = "Create GUI prototype", Description = "This task does some stuff in regards to the GUI prototype", ResourceAssigned = "Michelle", ExpectedStartDate = DateTime.Now.AddDays(3), ExpectedEndDate = DateTime.Now.AddDays(6),
                ExpectedDuration="2 days", ExpectedEffort=2, ActualStartDate = null, ActualEndDate = null, ActualDuration= null, EffortCompleted = null, ActualEffort = null, PercentCompleted = null, PredecessorTasks = new List<string>(),
                SuccessorTasks = new List<string>(), ListOfIssues = new List<string>(), TaskType=TaskType.Summary, ParentSummaryTask = string.Empty, GroupOtherTasks = new List<string>() },
            new Tasks() {Id = Guid.NewGuid(), Name = "Create detailed design", Description = "This task does some stuff in regards to the detailed design", ResourceAssigned = "Andranik", ExpectedStartDate = DateTime.Now.AddDays(4), ExpectedEndDate = DateTime.Now.AddDays(10),
                ExpectedDuration="2 days", ExpectedEffort=2, ActualStartDate = null, ActualEndDate = null, ActualDuration= null, EffortCompleted = null, ActualEffort = null, PercentCompleted = null, PredecessorTasks = new List<string>(),
                SuccessorTasks = new List<string>(), ListOfIssues = new List<string>(), TaskType=TaskType.Milestone, ParentSummaryTask = string.Empty, GroupOtherTasks = new List<string>() },
            new Tasks() {Id = Guid.NewGuid(), Name = "Create test cases", Description = "This task does some stuff in regards to test cases", ResourceAssigned = "Brandon", ExpectedStartDate = DateTime.Now.AddDays(5), ExpectedEndDate = DateTime.Now.AddDays(10),
                ExpectedDuration="2 days", ExpectedEffort=2, ActualStartDate = null, ActualEndDate = null, ActualDuration= null, EffortCompleted = null, ActualEffort = null, PercentCompleted = null, PredecessorTasks = new List<string>(),
                SuccessorTasks = new List<string>(), ListOfIssues = new List<string>(), TaskType=TaskType.Regular, ParentSummaryTask = string.Empty, GroupOtherTasks = new List<string>() }
        };

        public Task<List<Tasks>> GetTasksAsync()
        {
            var taskList = new List<Tasks>();
            foreach (var task in SeedTasks)
            {
                taskList.Add(task);
            }

            return Task.FromResult(taskList);
        }
    }
}
