using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GenericWarehouseWebsite.Data;
using GenericWarehouseWebsite.Models;

namespace GenericWarehouseWebsite.Pages.Tools
{
    public class DetailsModel : PageModel
    {
        private readonly GenericWarehouseWebsite.Data.WarehouseContext _context;

        public DetailsModel(GenericWarehouseWebsite.Data.WarehouseContext context)
        {
            _context = context;
        }

        public Tool Tool { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tool = await _context.Tools.SingleOrDefaultAsync(m => m.ID == id);

            if (Tool == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
