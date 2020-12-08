using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data;
using ProjectManagementSystem.Features.Resources.Models;
using ProjectManagementSystem.Features.Shared;
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
            var resources = await (from resource in this.db.Resource
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
            var resourceData = await (from resource in this.db.Resource                            
                                where resource.Id == Id
                                select resource).FirstAsync();

            return resourceData;
        }

        public async Task<List<ResourceSkill>> GetResourceSkillsByResourceId(Guid Id)
        {
            var resourceSkills = await (from resourceSkill in this.db.ResourceSkill
                                        where resourceSkill.ResourceId == Id.ToString()
                                        select resourceSkill).ToListAsync();
            return resourceSkills;
        }

        public int SaveResource(Resource resourceData, List<ResourceSkill> resourceSkills)
        {
            int entriesSaved = 0;
            
            var resource = new Resource()
            {
                Name = resourceData.Name,
                Title = resourceData.Title,
                PayRate = resourceData.PayRate,
                AvailabilityCalendar = resourceData.AvailabilityCalendar                
            };

            ResourceSkill resourceSkill = new ResourceSkill();

            foreach (var rs in resourceSkills)
            {
                resourceSkill = new ResourceSkill()
                {
                    SkillLevel = rs.SkillLevel,
                    SkillId = rs.SkillId,
                    ResourceId = resource.Id.ToString()
                };
            }

            try
            {
                this.db.Add(resource);
                if(resourceSkills.Count > 0)
                {
                    this.db.Add(resourceSkill);
                }
                
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
