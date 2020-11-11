using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Features.Skills
{
    public class Skill
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }        

        public Skill()
        {
            Id = Guid.NewGuid();
        }
    }

    internal class SkillEntityConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> skill)
        {
            skill.ToTable("Skill");

            skill.HasKey(x => x.Id);
            skill.Property(x => x.Name).IsRequired();
        }
    }
}