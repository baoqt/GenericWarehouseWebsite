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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GenericWarehouseWebsite.Pages.Components
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
        public Component Component { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Component.OwnerID = UserManager.GetUserId(User);

            // requires using ContactManager.Authorization;
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, Component,
                InformationAuthorization.Create);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Context.Component.Add(Component);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}