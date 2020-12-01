using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data;
using ProjectManagementSystem.Features.ActionItems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Features.ActionItems
{
    public class ActionItemService
    {
        private ApplicationDbContext db;

        public ActionItemService(ApplicationDbContext db)
        {
            this.db = db;
        }

     public async Task<List<ActionItems.Models.ActionItemListModel>> GetActionItemsListDataAsync()
        {
            var action_itemDataList = await (
                     from action_item in this.db.ActionItem
                     //join addResource in this.db.Resource on action_item.ResourceId equals addResource.Id
                     //join addIssue in this.db.Issue on action_item.IssueId equals addIssue.Id
                   // into ActionItemResourceData
                    // from resource in ActionItemResourceData.DefaultIfEmpty()
                     select new ActionItemListModel { 
                         ActionItemId = action_item.Id, 
                         ActionItemName = action_item.Name, 
                         ExpectedCompletionDate  = action_item.ExpectedCompletionDate, 
                         ActualCompletionDate = action_item.ActualCompletionDate, 
                         Status = action_item.status,
                         //IssueName = issue.Name,
                         //ResourceName = resource.Name
                     }
                         ).ToListAsync();

            return action_itemDataList;
        }

        public async Task<ActionItemModel> GetActionItemById(Guid ActionItemId)
        {
            var action_itemModel = await (
                from action_item in this.db.ActionItem
                where action_item.Id == ActionItemId
                select new ActionItemModel { ActionItem = action_item }
                    ).FirstOrDefaultAsync();

            return action_itemModel;
        }

        //public async Task<List<Task>> GetTasksDataAsync()
        //{
        //    var taskModel = await (
        //        from task in this.db.Task.Include(x => x.TaskIssue).ThenInclude(x => x.Issue)
        //        join addResource in this.db.Resource on task.ResourceId equals addResource.Id
        //        into TaskResourceData
        //        from resource in TaskResourceData.DefaultIfEmpty()
        //        select task
        //            ).ToListAsync();

        //    return taskModel;
        //}

        public int SaveActionItem(ActionItem action_itemData)
        {
            int entriesSaved = 0;

            var action_item = new ActionItem()
            {
                Name = action_itemData.Name,
                Description = action_itemData.Description,
                status = action_itemData.status,
                statusDescription = action_itemData.statusDescription,
                ExpectedCompletionDate = action_itemData.ExpectedCompletionDate,
                ActualCompletionDate = action_itemData.ActualCompletionDate,
               //ResourceId = action_itemData.ResourceId,
                //IssueId = action_itemData.IssueId,
                DateAssigned = action_itemData.DateAssigned,
                DateCreated = action_itemData.DateCreated,
                UpdateDate = action_itemData.UpdateDate,
            };

            try
            {
                this.db.Add(action_item);
                entriesSaved = this.db.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.Write(ex.Message);
            }

            return entriesSaved;
        }

    }
}
