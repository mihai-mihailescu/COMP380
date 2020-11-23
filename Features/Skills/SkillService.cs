using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Features.Skills
{
    public class SkillService
    {
        ApplicationDbContext db;
        public SkillService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<List<Skill>> GetSkillsAsync()
        {
            var skills = await (from skill in this.db.Skill
                                   select skill).ToListAsync();

            return skills;
        }
    }
}
