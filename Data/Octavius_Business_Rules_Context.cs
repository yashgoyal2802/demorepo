using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Octavius_Business_Rules.Models;

namespace Octavius_Business_Rules.Data
{
    public class Octavius_Business_Rules_Context : DbContext
    {
        public Octavius_Business_Rules_Context (DbContextOptions<Octavius_Business_Rules_Context> options)
            : base(options)
        {
        }

        public DbSet<Octavius_Business_Rules.Models.ThoughtLeaderModel> ThoughtLeaderModel { get; set; }
    }
}
