using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Emax.Identity
{
    public class IdentityUser : IUser<string>,IUser
    {
        public IdentityUser()
        {

        }

        public IdentityUser(string id)
        {
            this.Id = id;
        }
        public string Id { get; }

        public string UserName { get ; set ; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<IdentityUser> manager, string authenticationType)
        {

            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<IdentityUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }


    }
}
