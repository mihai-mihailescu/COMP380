using ProjectManagementSystem.Features.Resources;
using ProjectManagementSystem.Features.Shared;
using ProjectManagementSystem.Features.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProjectManagementSystem.Features.Deliverables.Models
{
    public class DeliverableModel
    {
        public Deliverable Deliverable { get; set; } = new Deliverable();

        public List<Tasks.Task> AssociatedTasks { get; set; } = new List<Tasks.Task>();

        public List<Requirements.Requirement> AssociatedRequirements { get; set; } = new List<Requirements.Requirement>();

    }
}
