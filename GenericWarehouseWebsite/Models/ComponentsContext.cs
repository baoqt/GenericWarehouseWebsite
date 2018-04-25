using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GenericWarehouseWebsite.Models
{
    public class ComponentsContext : DbContext
    {
        public ComponentsContext(DbContextOptions<ComponentsContext> options)
            : base(options)
        {

        }

        public DbSet<Components> Components { get; set; }
    }
}
