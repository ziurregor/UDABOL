using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Udabol_Tareas_Restful.Models
{
    public class RolContext:DbContext
    {
        public RolContext(DbContextOptions<RolContext> options):base(options) { 

        }

        public DbSet<Rol> Roles { get; set; }

    }
}
