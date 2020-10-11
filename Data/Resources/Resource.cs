using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Data.Resources
{
    public class Resource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string ListOfSkills { get; set; }
        public string AvailabilityCalendar { get; set; }
        public decimal PayRate { get; set; }       
        //In a db we would create a relation to the task table through this id
        public Guid AssignedTaskId { get; set; }
    }
}
