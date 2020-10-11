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
            new Resource() {Id = Guid.NewGuid(), Name = "Mihai", Title = "Architect", ListOfSkills ="C#, Java, SQL, HTML, CSS, Javascript, .NET CORE", AvailabilityCalendar=string.Empty, PayRate=45.29m, AssignedTaskId=Guid.NewGuid()},
            new Resource() {Id = Guid.NewGuid(), Name = "Richard", Title = "Developer", ListOfSkills ="C#, Java, SQL, HTML, CSS, Javascript, .NET CORE", AvailabilityCalendar=string.Empty, PayRate=40.23m, AssignedTaskId=Guid.NewGuid()},
            new Resource() {Id = Guid.NewGuid(), Name = "Michelle", Title = "QA Engineer", ListOfSkills ="C#, Java, Analyst", AvailabilityCalendar=string.Empty, PayRate=38.54m, AssignedTaskId=Guid.NewGuid()},
            new Resource() {Id = Guid.NewGuid(), Name = "Andranik", Title = "Business Analyst", ListOfSkills ="Analyst, Documentation, Mind reader", AvailabilityCalendar=string.Empty, PayRate=38.18m, AssignedTaskId=Guid.NewGuid()},
            new Resource() {Id = Guid.NewGuid(), Name = "Brandon", Title = "Designer", ListOfSkills ="HTML, CSS, Javascript", AvailabilityCalendar=string.Empty, PayRate=37.33m, AssignedTaskId=Guid.NewGuid()}
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
