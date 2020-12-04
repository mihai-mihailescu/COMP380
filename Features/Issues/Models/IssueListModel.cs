using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Features.Issues.Models
{
    public class IssueListModel
    {
        public Guid IssueId { get; set; }
        public string Name { get; set; }
        public string ActionItemName { get; set; }
        public string DecisionName { get; set; }
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
    }
}
