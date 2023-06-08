using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Emax.Identity
{
    public class IdentitySignInManager: SignInManager<IdentityUser, string>
    {
        public IdentitySignInManager(IdentityUserManager userManager, IAuthenticationManager authenticationManager)
    : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(IdentityUser user)
        {
            return user.GenerateUserIdentityAsync((IdentityUserManager)UserManager, DefaultAuthenticationTypes.ApplicationCookie);
        }

        public override Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
           // this.AuthenticationManager.SignIn()

            return base.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
        }

        public static IdentitySignInManager Create(IdentityFactoryOptions<IdentitySignInManager> options, IOwinContext context)
        {
            return new IdentitySignInManager(context.GetUserManager<IdentityUserManager>(), context.Authentication);
        }

    }
}
