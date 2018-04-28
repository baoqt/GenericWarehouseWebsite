using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GenericWarehouseWebsite.Models
{
    public class ToolContext : DbContext
    {
        public ToolContext(DbContextOptions<ToolContext> options)
            : base(options)
        {

        }

        public DbSet<Tool> Tool { get; set; }
    }
}
