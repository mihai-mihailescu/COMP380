using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        public Collection<AvailabilityCalendar> AvailabilityCalendar { get; set; }
        public Collection<Skill> Skill { get; set; }

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

            resource.OwnsMany(x => x.Skill,
                s =>
                {
                    s.ToTable("Skill");
                    s.HasKey(x => x.Id);
                    s.Property(x => x.Name);
                    s.Property(x => x.SkillLevel);
                    s.WithOwner().HasForeignKey(x => x.ResourceId);
                });
        }
    }

    public class AvailabilityCalendar
    {
        public Guid Id { get; private set; }
        public Guid ResourceId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        private AvailabilityCalendar()
        {
            Id = Guid.NewGuid();
        }
    }

    public class Skill
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public Guid ResourceId { get; set; }

        private Skill()
        {
            Id = Guid.NewGuid();
        }
    }
}
