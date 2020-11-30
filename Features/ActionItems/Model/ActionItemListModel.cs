using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Features.ActionItems.Models
{
    public class ActionItemListModel
    {
        public Guid ActionItemId { get; set; }
        public string IssueName { get; set; }
        public string ResourceName { get; set; }
        public string ActionItemName { get; set; }
        public string ActionItemDescription { get; set; }
        public string ActionItemStatus { get; set; }
        public string ActionItemStatusDescription { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateAssigned { get; set; }
        public

    }
}

