using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data;
using ProjectManagementSystem.Features.Issues.Models;
using ProjectManagementSystem.Features.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Features.Issues
{
    public class IssueService
    {
        ApplicationDbContext db;
        public IssueService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Issue>> GetIssuesDataAsync()
        {
            var issues = await (from issue in this.db.Issue
                                select issue).ToListAsync();
            return issues;
        }

        public async Task<List<IssueListModel>> GetIssuesListData(){
            var issueListData = await (from issue in this.db.Issue
                                       join addIssue in this.db.Issue on issue.Id equals addIssue.Id
                                       into issueTaskData
                                       from task in issueTaskData.DefaultIfEmpty()
                                       select new IssueListModel
                                       {
                                           IssueId = issue.Id,
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
                                           //UpdateDate = issue.UpdateDate,
                                       }).ToListAsync();
            return issueListData;
        }
        
        public async Task<Issue> GetIssueById(Guid Id){
            var issueData = await(from issue in this.db.Issue
                where issue.Id == Id
                select issue).FirstAsync();
            return issueData;
        }
         
        public async Task<int> SaveIssue(Issue issueData){
            int entriesSaved = 0;
            
            var issue = new Issue()
            {
                Name = issueData.Name,
                Description = issueData.Description,
                Priority = issueData.Priority,
                Severity = issueData.Severity,
                DateRaised = issueData.DateRaised,
                DateAssigned = issueData.DateAssigned,
                ExpectedCompletionDate = issueData.ExpectedCompletionDate,
                ActualCompletionDate = issueData.ActualCompletionDate,
                Status = issueData.Status,
                StatusDescription = issueData.StatusDescription,
                UpdateDate = issueData.UpdateDate
            };
            try
            {
                this.db.Add(issue);
                entriesSaved = this.db.SaveChanges();
            }
            catch(SqlException ex){
                Console.Write(ex.Message);
            }
            return entriesSaved;
        }
    }
}

