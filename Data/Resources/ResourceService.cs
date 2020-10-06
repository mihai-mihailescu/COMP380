using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Data.Resources
{
    public class ResourceService
    {
        private static readonly Resource[] SeedResources = new[]
        {
            new Resource() {Name = "Mihai", Title = "Architect", AssignedTask="Task1"},
            new Resource() {Name = "Richard", Title = "Developer", AssignedTask="Task2"},
            new Resource() {Name = "Michelle", Title = "QA Engineer", AssignedTask="Task3"},
            new Resource() {Name = "Andranik", Title = "Business Analyst", AssignedTask="Task4"},
            new Resource() {Name = "Brandon", Title = "Designer", AssignedTask="Task5"}
        };

        public Task<List<Resource>> GetResourcesAsync()
        {
            var resourceList = new List<Resource>();
            foreach(var resource in SeedResources)
            {
                resourceList.Add(resource);
            }

            return Task.FromResult(resourceList);
        }
    }
}
