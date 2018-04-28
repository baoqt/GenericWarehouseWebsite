using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GenericWarehouseWebsite.Models;

namespace GenericWarehouseWebsite.Pages.Tools
{
    public class IndexModel : PageModel
    {
        private readonly GenericWarehouseWebsite.Models.ToolContext _context;

        public IndexModel(GenericWarehouseWebsite.Models.ToolContext context)
        {
            _context = context;
        }

        public IList<Tool> Tool { get;set; }

        public async Task OnGetAsync()
        {
            Tool = await _context.Tool.ToListAsync();
        }
    }
}
