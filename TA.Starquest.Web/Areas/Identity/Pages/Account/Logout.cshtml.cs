using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TA.Starquest.DataAccess.Entities;
using TA.Utils.Core.Diagnostics;

namespace TA.Starquest.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIdentity user;
        private readonly ILog log;

        public LogoutModel(SignInManager<ApplicationUser> signInManager, IIdentity user, ILog log)
        {
            _signInManager = signInManager;
            this.user = user;
            this.log = log;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            log.Info()
                .Message("User {userName} logged out.", user.Name)
                .Write();
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
