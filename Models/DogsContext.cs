using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workspace.Models
{
    public class DogsContext : DbContext
    {
        public DogsContext(DbContextOptions<DogsContext> options)
           : base(options)
        {
        }

        public DbSet<workspace.Models.Dogs> Dog { get; set; }
    }
}
