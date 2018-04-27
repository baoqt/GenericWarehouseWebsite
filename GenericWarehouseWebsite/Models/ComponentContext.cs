using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GenericWarehouseWebsite.Models
{
    public class ComponentContext : DbContext
    {
        public ComponentContext(DbContextOptions<ComponentContext> options)
            : base(options)
        {

        }

        public DbSet<Component> Component { get; set; } 
    }
}
