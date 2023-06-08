
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emax.Identity
{
    public class IdentityUserManager: UserManager<IdentityUser>
    {
        public IdentityUserManager(IUserStore<IdentityUser> store)
            : base(store)
        {
            
           
        }


        public static IdentityUserManager Create(IdentityFactoryOptions<IdentityUserManager> options, IOwinContext context)
        {
            var manager = new IdentityUserManager(new IdentityUserDataStore());
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<IdentityUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true,
                
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = false,
                RequireUppercase = false,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        public override Task<bool> CheckPasswordAsync(IdentityUser user, string password)
        {
           

            return ((IdentityUserDataStore)this.Store).CheckPasswordAsync(user, password);
        }


    }
}
