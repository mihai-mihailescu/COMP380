using ProjectManagementSystem.Features.Issues;
using ProjectManagementSystem.Features.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Features.Tasks.Models
{
    public class TaskListModel
    {
        public Guid TaskId { get; set; }
        public string TaskName { get; set; }        
        public string ResourceName { get; set; }
        public DateTime? ExpectedStartDate { get; set; }
        public DateTime? ExpectedEndDate { get; set; }
        public TaskType TaskType { get; set; }
    }
}
