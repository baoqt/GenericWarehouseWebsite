using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericWarehouseWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericWarehouseWebsite.Data
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {

        }
        public DbSet<GenericWarehouseWebsite.Models.Account> Account { get; set; }
    }
}
