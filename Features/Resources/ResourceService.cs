using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data;
using ProjectManagementSystem.Features.Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Features.Resources
{
    public class ResourceService
    {
        ApplicationDbContext db;

        public ResourceService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Resource>> GetResourcesAsync()
        {
            var resources = await(from resource in this.db.Resource
                                    select resource).ToListAsync();

            return resources;
        }

        public async Task<List<ResourceListModel>> GetResourceListData()
        {
            var resourceListData = await (from resource in this.db.Resource
                                   join addTask in this.db.Task on resource.Id equals addTask.ResourceId
                                   into ResourceTaskData
                                   from task in ResourceTaskData.DefaultIfEmpty()
                                   select new ResourceListModel {ResourceId = resource.Id, ResourceName = resource.Name, ResourceTitle = resource.Title, PayRate = resource.PayRate, TaskName = task.Name}).ToListAsync();
            return resourceListData;
        }

        public async Task<Resource> GetResourceById(Guid Id)
        {
            var resource = await this.db.Resource.FindAsync(Id);                                  

            return resource;
        }
    }
}
