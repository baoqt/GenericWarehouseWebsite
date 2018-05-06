using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericWarehouseWebsite.Models;
using Microsoft.EntityFrameworkCore;
using Component = System.ComponentModel.Component;

namespace GenericWarehouseWebsite.Data
{
    public class WarehouseContext: DbContext
    {
        public WarehouseContext(DbContextOptions<WarehouseContext> options): base(options)
        { }

        public DbSet<Models.Component> Components { get; set; }
        public DbSet<Tool> Tools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Component>().ToTable("Component");
            modelBuilder.Entity<Tool>().ToTable("Tool");
            
        }

    }
}
