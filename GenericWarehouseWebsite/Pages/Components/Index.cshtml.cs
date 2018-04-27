using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GenericWarehouseWebsite.Models;

namespace GenericWarehouseWebsite.Pages.Components
{
    public class IndexModel : PageModel
    {
        private readonly GenericWarehouseWebsite.Models.ComponentContext _context;

        public IndexModel(GenericWarehouseWebsite.Models.ComponentContext context)
        {
            _context = context;
        }

        public IList<Component> Component { get;set; }

        public async Task OnGetAsync()
        {
            Component = await _context.Component.ToListAsync();
        }
    }
}
