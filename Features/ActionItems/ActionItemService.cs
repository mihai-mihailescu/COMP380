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

     public async Task<List<ActionItemListModel>> GetActionItemsListDataAsync()
        {
          
            var action_itemDataList = await (
                from action_item in this.db.ActionItem

                join addResource in this.db.Resource on action_item.ResourceId equals addResource.Id
                into ActionItemResourceData
                from resource in ActionItemResourceData.DefaultIfEmpty()

                join addIssue in this.db.Issue on action_item.IssueId equals addIssue.Id
                into ActionItemIssueData
                from issue in ActionItemIssueData.DefaultIfEmpty()

                select new ActionItemListModel
                {
                    ActionItemId = action_item.Id,
                    ActionItemName = action_item.Name,
                    ExpectedCompletionDate = action_item.ExpectedCompletionDate,
                    ActualCompletionDate = action_item.ActualCompletionDate,
                    UpdateDate = action_item.UpdateDate,
                    Status = action_item.status,
                    StatusDescription = action_item.statusDescription,
                    DateAssigned = action_item.DateAssigned,
                    DateCreated = action_item.DateCreated,
                    IssueName = issue.Name,
                    ResourceName =  resource.Name,
                }
                ).ToListAsync();
            return action_itemDataList;
        }

        public async Task<ActionItemModel> GetActionItemById(Guid Id)
        {
            var action_itemModel = await (
                from action_item in this.db.ActionItem
                where action_item.Id == Id
                select new ActionItemModel { ActionItem = action_item }
                    ).FirstOrDefaultAsync();

            return action_itemModel;
        }

        public async Task<List<ActionItem>> GetActionItemDataAsync()
        {
            var action_item = await (from ActionItem in this.db.ActionItem
                                     select ActionItem).ToListAsync();
            return action_item;
        }

        public async Task<List<ActionItem>> GetActionItemsByIssueId(Guid IssueId)
        {
            var action_item = await (from ActionItem in this.db.ActionItem
                                     where ActionItem.IssueId == IssueId
                                     select ActionItem).ToListAsync();
            return action_item;
        }

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
                DateAssigned = action_itemData.DateAssigned,
                UpdateDate = action_itemData.UpdateDate,
                DateCreated = action_itemData.DateCreated,
                ResourceId = action_itemData.ResourceId,
                IssueId = action_itemData.IssueId,
                
                
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
