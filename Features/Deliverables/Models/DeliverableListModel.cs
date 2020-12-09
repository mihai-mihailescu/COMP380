using ProjectManagementSystem.Features.Issues;
using ProjectManagementSystem.Features.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Features.Deliverables.Models
{
    public class DeliverableListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
