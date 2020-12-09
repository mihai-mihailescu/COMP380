using ProjectManagementSystem.Features.Issues;
using ProjectManagementSystem.Features.Shared;
using ProjectManagementSystem.Features.ActionItems;
using ProjectManagementSystem.Features.Decisions;
using System.Collections.Generic;

namespace ProjectManagementSystem.Features.Issues.Models
{
    public class IssueModel
    {
        public Issue Issue { get; set; } = new Issue();

        public List<ActionItem> AssociatedActionItems = new List<ActionItem>();

        public List<Decision> AssociatedDecision = new List<Decision>();
    }
}
