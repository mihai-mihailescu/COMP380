using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.Features.Resources;
using ProjectManagementSystem.Features.Skills;
using System;
using System.Collections.ObjectModel;

namespace ProjectManagementSystem.Features.Shared
{
    public class ResourceSkill
    {
        public Guid Id { get; private set; }        
        public string ResourceId { get; set; }
        public Guid SkillId { get; set; }
        public SkillLevel SkillLevel { get; set; }

        public ResourceSkill()
        {
            Id = Guid.NewGuid();
        }
    }

    internal class ResourceSkillEntityConfiguration : IEntityTypeConfiguration<ResourceSkill>
    {
        public void Configure(EntityTypeBuilder<ResourceSkill> resourceSkill)
        {
            resourceSkill.ToTable("ResourceSkill");

            resourceSkill.HasKey(x => x.Id).IsClustered(false);
            resourceSkill.Property(x => x.SkillLevel).IsRequired();
            resourceSkill.HasOne<Skill>().WithOne().HasForeignKey<ResourceSkill>(x => x.SkillId).HasConstraintName("FK_SkillId");
            resourceSkill.Property(x => x.ResourceId);
        }
    }

    public enum SkillLevel
    {
        Low,
        Medium,
        High
    }
}
