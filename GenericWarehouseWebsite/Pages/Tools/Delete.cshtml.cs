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
using GenericWarehouseWebsite.Pages.Components;
using GenericWarehouseWebsite.Pages.Tools;

namespace GenericWarehouseWebsite.Pages.Tools
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
        public Tool Tool { get; set; }
        public string ErrorMessage { get; set; }


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
                InformationAuthorization.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Tool = await Context.Tool.FindAsync(id);

            var contact = await Context
                .Tool.AsNoTracking()
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

            Context.Tool.Remove(Tool);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}