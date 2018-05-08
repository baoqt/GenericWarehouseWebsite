using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GenericWarehouseWebsite.Data;
using GenericWarehouseWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GenericWarehouseWebsite.Authorization;

namespace GenericWarehouseWebsite.Pages.Components
{
    public class DeleteModel : DI_BasePageModel
    {
        private readonly GenericWarehouseWebsite.Data.WarehouseContext _context;

        public DeleteModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<ApplicationUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }
        [BindProperty]
        public Component Component { get; set; }
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Component = await Context.Component.FirstOrDefaultAsync(
                m => m.ID == id);

            if (Component == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, Component,
                InformationAuthorization.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Component = await Context.Component.FindAsync(id);

            var contact = await Context
                .Component.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (contact == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, contact,
                InformationAuthorization.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Context.Component.Remove(Component);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}