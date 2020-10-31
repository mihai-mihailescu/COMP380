using ProjectManagementSystem.Features.Resources;
using ProjectManagementSystem.Features.Shared;

namespace ProjectManagementSystem.Features.Tasks.Models
{
    public class TaskModel
    {
        public Task Task { get; set; } = new Task();
        public Resource Resource { get; set; } = new Resource();        
    }
}
