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
        
        public async Task<List<IssueListModel>> GetIssuesListDataAsync(){
            var issueDataList = await(
                from issue in this.db.Issue
                //What to link here
                select new IssueListModel
                {
                    Id = issue.Id,
                    Name = issue.Name,
                    Description = issue.Description,
                    Priority = issue.Priority,
                    Severity = issue.Severity,
                    DateRaised = issue.DateRaised,
                    DateAssigned = issue.DateAssigned,
                    ExpectedCompletionDate = issue.ExpectedCompletionDate,
                    ActualCompletionDate = issue.ActualCompletionDate, 
                    Status = issue.Status,
                    StatusDescription = issue.StatusDescription,
                    UpdateDate = issue.UpdateDate
                }
            ).ToListAsync();
            return issueDataList;
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
