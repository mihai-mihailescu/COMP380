using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data;
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
    }
}
