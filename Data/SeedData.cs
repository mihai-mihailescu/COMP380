using ProjectManagementSystem.Features.Issues;
using ProjectManagementSystem.Features.Resources;
using ProjectManagementSystem.Features.Shared;
using ProjectManagementSystem.Features.Skills;
using ProjectManagementSystem.Features.Tasks;
using ProjectManagementSystem.Features.ActionItems;

using System;
using System.Linq;

namespace ProjectManagementSystem.Data
{
    public class SeedData
    {
        public static void Seed(ApplicationDbContext db)
        {
            SeedResources(db);
            SeedTasks(db);
            SeedIssues(db);
            SeedSkills(db);
            SeedActionItems(db);
        }

        private static void SeedResources(ApplicationDbContext db)
        {
            var resources = db.Resource.Select(x => x.Id).ToList();

            if (resources.Count == 0)
            {
                var resourcesToAdd = new[]
                {
                    new Resource() {Name = "Mihai", Title = "Architect"},
                    new Resource() {Name = "Richard", Title = "Developer"},
                    new Resource() {Name = "Michelle", Title = "QA Engineer"},
                    new Resource() {Name = "Andranik", Title = "Business Analyst"},
                    new Resource() {Name = "Brandon", Title = "Designer"}
                };
                db.Set<Resource>().AddRange(resourcesToAdd);

                db.SaveChanges();
            }
        }

        private static void SeedTasks(ApplicationDbContext db)
        {
            var task = db.Task.Select(x => x.Id).ToList();            

            if (task.Count == 0)
            {
                var tasksToAdd = new[]
                {
                    new Task() {Name = "Write user stories", Description = "This task does some stuff in regards to the writing user stories", ExpectedStartDate = DateTime.Now.AddDays(1).Date, ExpectedEndDate = DateTime.Now.AddDays(3).Date,
                        ExpectedDuration="2 days", ExpectedEffort=2, ActualStartDate = null, ActualEndDate = null, ActualDuration= null, EffortCompleted = null, ActualEffort = null, PercentCompleted = null, TaskType=TaskType.Regular, ParentSummaryTaskId = null},
                    new Task() {Name = "Create high level design", Description = "This task does some stuff in regards to creating high level design", ExpectedStartDate = DateTime.Now.AddDays(2).Date, ExpectedEndDate = DateTime.Now.AddDays(3).Date,
                        ExpectedDuration="2 days", ExpectedEffort=2, ActualStartDate = null, ActualEndDate = null, ActualDuration= null, EffortCompleted = null, ActualEffort = null, PercentCompleted = null, TaskType=TaskType.Summary, ParentSummaryTaskId = null},
                    new Task() {Name = "Create GUI prototype", Description = "This task does some stuff in regards to the GUI prototype", ExpectedStartDate = DateTime.Now.AddDays(3).Date, ExpectedEndDate = DateTime.Now.AddDays(6).Date,
                        ExpectedDuration="2 days", ExpectedEffort=2, ActualStartDate = null, ActualEndDate = null, ActualDuration= null, EffortCompleted = null, ActualEffort = null, PercentCompleted = null, TaskType=TaskType.Summary, ParentSummaryTaskId = null},
                    new Task() {Name = "Create detailed design", Description = "This task does some stuff in regards to the detailed design", ExpectedStartDate = DateTime.Now.AddDays(4).Date, ExpectedEndDate = DateTime.Now.AddDays(10).Date,
                        ExpectedDuration="2 days", ExpectedEffort=2, ActualStartDate = null, ActualEndDate = null, ActualDuration= null, EffortCompleted = null, ActualEffort = null, PercentCompleted = null, TaskType=TaskType.Milestone, ParentSummaryTaskId = null},
                    new Task() {Name = "Create test cases", Description = "This task does some stuff in regards to test cases", ExpectedStartDate = DateTime.Now.AddDays(5).Date, ExpectedEndDate = DateTime.Now.AddDays(10).Date,
                        ExpectedDuration="2 days", ExpectedEffort=2, ActualStartDate = null, ActualEndDate = null, ActualDuration= null, EffortCompleted = null, ActualEffort = null, PercentCompleted = null, TaskType=TaskType.Regular, ParentSummaryTaskId = null}
                };
                db.Set<Task>().AddRange(tasksToAdd);
                db.SaveChanges();
            }
        }

        private static void SeedIssues(ApplicationDbContext db)
        {
            var issue = db.Issue.Select(x => x.Id).ToList();

            if (issue.Count == 0)
            {
                var issuesToAdd = new[]
                {
                    new Issue(){Name = "Issue 1"},
                    new Issue(){Name = "Issue 2"},
                    new Issue(){Name = "Issue 3"},
                    new Issue(){Name = "Issue 4"}
                };
                db.Set<Issue>().AddRange(issuesToAdd);
                db.SaveChanges();
            }
        }

        private static void SeedSkills(ApplicationDbContext db)
        {
            var skill = db.Skill.Select(x => x.Id).ToList();

            if(skill.Count == 0)
            {
                var skillsToAdd = new[]
                {
                    new Skill(){Name = "C#"},
                    new Skill(){Name = "Java"},
                    new Skill(){Name = "Html"},
                    new Skill(){Name = "CSS"},
                    new Skill(){Name = "Javascript"},
                    new Skill(){Name = "Typescript"},
                    new Skill(){Name = "Blazor"},
                    new Skill(){Name = "SQL"},
                    new Skill(){Name = "Integration Testing"},
                    new Skill(){Name = "Unit Testing"},
                    new Skill(){Name = "Manual Testing"},
                    new Skill(){Name = "Automated UI Testing"},
                    new Skill(){Name = "Marketing"},
                    new Skill(){Name = "Project Management"},
                    new Skill(){Name = "Documentation"},
                    new Skill(){Name = "Sales"},
                    new Skill(){Name = "Network Security"},
                    new Skill(){Name = "API Development"}
                };
                db.Set<Skill>().AddRange(skillsToAdd);
                db.SaveChanges();
            }
        }
   
        private static void SeedActionItems(ApplicationDbContext db)
        {
            var action_item = db.ActionItem.Select(x => x.Id).ToList();

            if (action_item.Count == 0)
            {
                var action_itemToAdd = new[]
               {
                    new ActionItem(){ 
                        Name = "Action Item 1",
                        Description = "description", 
                        DateCreated = DateTime.Now, 
                        DateAssigned = DateTime.Now,
                        ActualCompletionDate = DateTime.Now, 
                        ExpectedCompletionDate = DateTime.Now, 
                        status = Features.ActionItems.Status.Closed, 
                        statusDescription = null,    
                        UpdateDate = DateTime.Now,
                        //ResourceId = Guid.Empty,
                        //IssueId = Guid.Empty,
                    }
            
                  
                };
                db.Set<ActionItem>().AddRange(action_itemToAdd);
                db.SaveChanges();
            }

        }


    
    
    }

}
