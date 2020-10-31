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
                select new TaskListModel { TaskId = task.Id, TaskName = task.Name, ExpectedStartDate = task.ExpectedStartDate, ExpectedEndDate = task.ExpectedEndDate, TaskType = task.TaskType, ResourceName = resource.Name }
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

        public int SaveTask(Task taskData)
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
                TaskGroup = taskData.TaskGroup,
                DeliverableId = taskData.DeliverableId,
                ResourceId = taskData.ResourceId,
                TaskIssue = taskData.TaskIssue,
            };

            try
            {
                this.db.Add(task);
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
