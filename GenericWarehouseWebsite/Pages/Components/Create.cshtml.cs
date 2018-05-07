using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GenericWarehouseWebsite.Data;
using GenericWarehouseWebsite.Models;

namespace GenericWarehouseWebsite.Pages.Components
{
    public class CreateModel : PageModel
    {
        private readonly GenericWarehouseWebsite.Data.WarehouseContext _context;

        public CreateModel(GenericWarehouseWebsite.Data.WarehouseContext context)
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

            var emptyComponent = new Component();

            if (await TryUpdateModelAsync<Component>(
                emptyComponent,
                "component",
                s => s.Bin, s => s.Quantity, s => s.PartNumber, s => s.Cost, s => s.Name, s => s.Description))
            {
                _context.Components.Add(Component);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            return null;
        }
    }
}