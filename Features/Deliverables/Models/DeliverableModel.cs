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

        public Collection<Tasks.Task> AssociatedTasks { get; set; } = new Collection<Tasks.Task>();

        public Collection<Requirements.Requirement> AssociatedRequirements { get; set; } = new Collection<Requirements.Requirement>();

    }
}
