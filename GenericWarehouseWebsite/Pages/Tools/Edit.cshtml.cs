using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericWarehouseWebsite.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GenericWarehouseWebsite.Data;
using GenericWarehouseWebsite.Models;
using GenericWarehouseWebsite.Pages.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.KeyVault.Models;

namespace GenericWarehouseWebsite.Pages.Tools
{
    public class EditModel : DI_BasePageModel
    {

        public EditModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<ApplicationUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public Tool Tool { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Tool = await Context.Tool.FirstOrDefaultAsync(
                m => m.ID == id);

            if (Tool == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, Tool,
                InformationAuthorization.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Fetch Contact from DB to get OwnerID.
            var contact = await Context
                .Tool.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (contact == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, contact,
                InformationAuthorization.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Tool.OwnerID = contact.OwnerID;

            Context.Attach(Tool).State = EntityState.Modified;

            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool ContactExists(int id)
        {
            return Context.Tool.Any(e => e.ID == id);
        }
    }
}