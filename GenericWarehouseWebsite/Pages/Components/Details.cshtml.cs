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
    public class DetailsModel : PageModel
    {
        private readonly GenericWarehouseWebsite.Models.ComponentContext _context;

        public DetailsModel(GenericWarehouseWebsite.Models.ComponentContext context)
        {
            _context = context;
        }

        public Component Component { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Component = await _context.Component.SingleOrDefaultAsync(m => m.ID == id);

            if (Component == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
