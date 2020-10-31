using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Features.Issues
{
    public class IssueService
    {
        private ApplicationDbContext db;
        public IssueService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Issue>> GetIssuesDataAsync()
        {
            var issueModel = await (
                from issue in this.db.Issue
                select issue).ToListAsync();

            return issueModel;
        }
    }
}
