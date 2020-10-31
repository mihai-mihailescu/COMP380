using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Features.ActionItems;
using ProjectManagementSystem.Features.Decision;
using ProjectManagementSystem.Features.Deliverables;
using ProjectManagementSystem.Features.Issues;
using ProjectManagementSystem.Features.Requirements;
using ProjectManagementSystem.Features.Resources;
using ProjectManagementSystem.Features.Shared;
using ProjectManagementSystem.Features.Tasks;

namespace ProjectManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<Task> Task { get; set; }
        public DbSet<Resource> Resource { get; set; }               
        public DbSet<Issue> Issue { get; set; }
        public DbSet<ActionItem> ActionItem { get; set; }
        public DbSet<Decision> Decision { get; set; }
        public DbSet<Deliverable> Deliverable { get; set; }
        public DbSet<Requirement> Requirement { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
