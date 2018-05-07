using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GenericWarehouseWebsite.Data;
using GenericWarehouseWebsite.Models;

namespace GenericWarehouseWebsite.Pages.Components
{
    public class DeleteModel : PageModel
    {
        private readonly GenericWarehouseWebsite.Data.WarehouseContext _context;

        public DeleteModel(GenericWarehouseWebsite.Data.WarehouseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Component Component { get; set; }
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Component = await _context.Components
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Component == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var component = await _context.Components
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (component == null)
            {
                return NotFound();
            }

            try
            {
                _context.Components.Remove(component);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                    new { id = id, saveChangesError = true });
            }
        }
    }
}