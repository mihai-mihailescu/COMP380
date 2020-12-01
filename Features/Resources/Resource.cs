using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.Features.Skills;
using System;
using System.Collections.ObjectModel;

namespace ProjectManagementSystem.Features.Resources
{
    public class Resource
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Title { get; set; }               
        public decimal PayRate { get; set; }
        public Collection<AvailabilityCalendar> AvailabilityCalendar { get; set; } = new Collection<AvailabilityCalendar>();       

        public Resource()
        {
            Id = Guid.NewGuid();
        }
    }

    internal class ResourceEntityConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> resource)
        {
            resource.ToTable("Resource");

            resource.HasKey(x => x.Id);
            resource.Property(x => x.Name).IsRequired();
            resource.Property(x => x.Title);            
            resource.Property(x => x.PayRate).HasColumnType("decimal(6,2)");

            resource.OwnsMany(x => x.AvailabilityCalendar,
                ac =>
                {
                    ac.ToTable("AvailabilityCalendar");
                    ac.HasKey(x => x.Id);                    
                    ac.Property(x => x.From);
                    ac.Property(x => x.To);
                    ac.WithOwner().HasForeignKey(x => x.ResourceId);
                });
        }
    }

    public class AvailabilityCalendar
    {
        public Guid Id { get; set; }
        public Guid ResourceId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }        
    }
}
