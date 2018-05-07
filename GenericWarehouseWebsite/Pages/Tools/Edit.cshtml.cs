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
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GenericWarehouseWebsite.Pages.Tools
{
    public class EditModel : PageModel
    {
        private readonly GenericWarehouseWebsite.Data.WarehouseContext _context;

        public EditModel(GenericWarehouseWebsite.Data.WarehouseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tool Tool { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Tool = await _context.Tools.FirstOrDefaultAsync(m => m.ID == id);
            Tool = await _context.Tools.FindAsync(id);
            if (Tool == null)
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

            _context.Attach(Tool).State = EntityState.Modified;
            var toolToUpdate = await _context.Tools.FindAsync(id);

            
            if (await TryUpdateModelAsync<Tool>(
                toolToUpdate,
                "tool",
                s => s.Bin, s => s.Quantity, s => s.PartNumber, s => s.Cost, s => s.Name, s => s.Description))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToolExists(Tool.ID))
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

        private bool ToolExists(int id)
        {
            return _context.Tools.Any(e => e.ID == id);
        }
    }
}
