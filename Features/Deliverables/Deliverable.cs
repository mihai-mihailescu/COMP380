using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.Features.Tasks.Pages;
using System.Collections.ObjectModel;
using System;

namespace ProjectManagementSystem.Features.Deliverables
{
    public class Deliverable
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }

        public Deliverable()
        {
            Id = Guid.NewGuid();
        }
    }

    internal class DeliverableEntityConfiguration : IEntityTypeConfiguration<Deliverable>
    {   
        public void Configure(EntityTypeBuilder<Deliverable> deliverable)
        {
            deliverable.ToTable("Deliverable");

            deliverable.HasKey(x => x.Id);
            deliverable.Property(x => x.Name);
            deliverable.Property(x => x.Description);
            deliverable.Property(x => x.DueDate);
            //Requirements will have the FK for Deliverables
            //Tasks will have the FK for Deliverables
        }
    }
}
