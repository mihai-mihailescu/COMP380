using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagementSystem.Features.Issues;

namespace ProjectManagementSystem.Features.Decisions
{
    public class DecisionService
    {
        private ApplicationDbContext db;
        public DecisionService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Decision>> GetDecisionsDataAsync()
        {
            var decisions = await (
                from decision in this.db.Decision
                select decision).ToListAsync();

            return decisions;
        }

        public async Task<List<Decision>> GetAssociatedDecisions(Issue issue)
        {
            var decisions = await (
                from decision in this.db.Decision
                where decision.IssueId == issue.Id
                select decision).ToListAsync();

            return decisions;
        }

        //Can be overloaded for appropriate object
        public async Task<List<Decision>> GetUnassociatedDecisions(Issue issue)
        {
            var decisions = await (
                from decision in this.db.Decision
                where decision.IssueId == null
                select decision).ToListAsync();

            return decisions;
        }
    }
}
