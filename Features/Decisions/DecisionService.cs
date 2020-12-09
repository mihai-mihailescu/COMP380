using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<List<Decision>> GetDecisionsByIssueId(Guid issueId)
        {
            var decisions = await (
                from decision in this.db.Decision
                where decision.IssueId == issueId
                select decision).ToListAsync();

            return decisions;
        }
    }
}
