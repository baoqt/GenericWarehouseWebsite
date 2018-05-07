using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GenericWarehouseWebsite.Data;
using GenericWarehouseWebsite.Models;

namespace GenericWarehouseWebsite.Pages_Accounts
{
    public class IndexModel : PageModel
    {
        private readonly GenericWarehouseWebsite.Data.AccountContext _context;

        public IndexModel(GenericWarehouseWebsite.Data.AccountContext context)
        {
            _context = context;
        }

        public IList<Account> Account { get;set; }

        public async Task OnGetAsync()
        {
            Account = await _context.Account.ToListAsync();
        }
    }
}
