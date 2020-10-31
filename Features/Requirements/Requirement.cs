using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Features.Requirements
{
    public class Requirement
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }

        public Requirement()
        {
            Id = Guid.NewGuid();
        }
    }

    internal class RequirementEntityConfiguration : IEntityTypeConfiguration<Requirement>
    {
        public void Configure(EntityTypeBuilder<Requirement> requirement)
        {
            requirement.ToTable("Requirement");

            requirement.HasKey(x => x.Id);
            requirement.Property(x => x.Name);
        }
    }
}
