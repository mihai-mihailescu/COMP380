using ProjectManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Features.Requirements
{
    public class RequirementService
    {
        private ApplicationDbContext db;

        public RequirementService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<Requirement> GetRequirementByDeliverableId(Guid DeliverableId)
        {
            var requirement = (
                from r in this.db.Requirement
                where r.DeliverableId == DeliverableId
                select r
                    ).ToList();

            return requirement;
        }

        public List<Requirement> GetUnassociatedRequirementsDataAsync()
        {
            var requirement = (
                from r in this.db.Requirement
                where r.DeliverableId == null
                select r).ToList();

            return requirement;
        }
    }

}
