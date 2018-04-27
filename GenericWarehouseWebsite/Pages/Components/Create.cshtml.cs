using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GenericWarehouseWebsite.Models;

namespace GenericWarehouseWebsite.Pages.Components
{
    public class CreateModel : PageModel
    {
        private readonly GenericWarehouseWebsite.Models.ComponentContext _context;

        public CreateModel(GenericWarehouseWebsite.Models.ComponentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Component Component { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Component.Add(Component);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}