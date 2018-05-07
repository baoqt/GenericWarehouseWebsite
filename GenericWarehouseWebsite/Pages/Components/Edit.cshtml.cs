using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GenericWarehouseWebsite.Data;
using GenericWarehouseWebsite.Models;

namespace GenericWarehouseWebsite.Pages.Components
{
    public class EditModel : PageModel
    {
        private readonly GenericWarehouseWebsite.Data.WarehouseContext _context;

        public EditModel(GenericWarehouseWebsite.Data.WarehouseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Component Component { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Component = await _context.Components.FirstOrDefaultAsync(m => m.ID == id);
            Component = await _context.Components.FindAsync(id);

            if (Component == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Component).State = EntityState.Modified;
            var componentToUpdate = await _context.Components.FindAsync(id);

            if (await TryUpdateModelAsync<Component>(
                componentToUpdate,
                "component",
                s => s.Bin, s => s.Quantity, s => s.PartNumber, s => s.Cost, s => s.Name, s => s.Description))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComponentExists(Component.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Page();
        }

        private bool ComponentExists(int id)
        {
            return _context.Components.Any(e => e.ID == id);
        }
    }
}
