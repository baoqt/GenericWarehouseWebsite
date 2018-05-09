using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericWarehouseWebsite.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GenericWarehouseWebsite.Data;
using GenericWarehouseWebsite.Models;
using GenericWarehouseWebsite.Pages.Components;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GenericWarehouseWebsite.Pages.Tools
{
    public class CreateModel : DI_BasePageModel
    {
        private readonly GenericWarehouseWebsite.Data.WarehouseContext _context;

        public CreateModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<ApplicationUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tool Tool { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Tool.OwnerID = UserManager.GetUserId(User);

            // requires using ContactManager.Authorization;
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, Tool,
                InformationAuthorization.Create);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Context.Tool.Add(Tool);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}