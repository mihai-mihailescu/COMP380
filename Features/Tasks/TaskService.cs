using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data;
using ProjectManagementSystem.Features.Tasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Features.Tasks
{
    public class TaskService
    {
        private ApplicationDbContext db;

        public TaskService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<TaskListModel>> GetTasksListDataAsync()
        {
            var taskDataList = await (
                from task in this.db.Task
                join addResource in this.db.Resource on task.ResourceId equals addResource.Id
                into TaskResourceData
                from resource in TaskResourceData.DefaultIfEmpty()
                select new TaskListModel { TaskId = task.Id, 
                    TaskName = task.Name, 
                    ExpectedStartDate = task.ExpectedStartDate, 
                    ExpectedEndDate = task.ExpectedEndDate, 
                    TaskType = task.TaskType, 
                    ResourceName = resource.Name }
                    ).ToListAsync();

            return taskDataList;
        }

        public async Task<TaskModel> GetTaskById(Guid TaskId)
        {
            var taskModel = await (
                from task in this.db.Task
                join addResource in this.db.Resource on task.ResourceId equals addResource.Id
                into TaskResourceData
                from resource in TaskResourceData.DefaultIfEmpty()
                where task.Id == TaskId
                select new TaskModel { Task = task, Resource = resource }
                    ).FirstOrDefaultAsync();

            return taskModel;
        }

        public async Task<List<Tasks.Task>> GetTaskByDeliverableId(Guid DeliverableId)
        {
            var task = await (
                from t in this.db.Task
                where t.DeliverableId == DeliverableId
                select t
                    ).ToListAsync();

            return task;
        }

        public async Task<List<Task>> GetTasksDataAsync()
        {
            var taskModel = await (
                from task in this.db.Task.Include(x => x.TaskIssue).ThenInclude(x => x.Issue)
                join addResource in this.db.Resource on task.ResourceId equals addResource.Id
                into TaskResourceData
                from resource in TaskResourceData.DefaultIfEmpty()
                select task
                    ).ToListAsync();

            return taskModel;
        }

        public async Task<List<Task>> GetUnassociatedTasksAsync()
        {
            var task = await (
                from t in this.db.Task
                where t.DeliverableId == null
                select t
                ).ToListAsync();

            return task;
        }
        public async Task<int> SaveTask(Task taskData)
        {
            int entriesSaved = 0;

            var task = new Task()
            {
                Name = taskData.Name,
                Description = taskData.Description,
                TaskType = taskData.TaskType,
                ExpectedStartDate = taskData.ExpectedStartDate,
                ExpectedEndDate = taskData.ExpectedEndDate,
                ExpectedDuration = taskData.ExpectedDuration,
                ExpectedEffort = taskData.ExpectedEffort,
                ActualStartDate = taskData.ActualStartDate,
                ActualEndDate = taskData.ActualEndDate,
                ActualDuration = taskData.ActualDuration,
                EffortCompleted = taskData.EffortCompleted,
                ActualEffort = taskData.ActualEffort,
                PercentCompleted = taskData.PercentCompleted,
                ParentSummaryTaskId = taskData.ParentSummaryTaskId,
                TaskPredecessor = taskData.TaskPredecessor,
                TaskSuccessor = taskData.TaskSuccessor,
                ParentGroupTaskId = taskData.ParentGroupTaskId,
                DeliverableId = taskData.DeliverableId,
                ResourceId = taskData.ResourceId,
                TaskIssue = taskData.TaskIssue,
            };

            try
            {
                this.db.Add(task);
                entriesSaved = await this.db.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                Console.Write(ex.Message);
            }

            return entriesSaved;
        }
    }
}
