using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Features.Resources.Models
{
    public class ResourceListModel
    {
        public Guid ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceTitle { get; set; }
        public decimal PayRate { get; set; }
        public string TaskName { get; set; }
    }
}
