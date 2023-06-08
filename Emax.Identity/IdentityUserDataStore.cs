using Emax.Identity;
using EMax.Dal.Context;
using EMax.Dal.Interface;
using EMax.Dal.Repository;
using EMax.DbModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Emax.Identity
{
    public class IdentityUserDataStore : IUserLoginStore<IdentityUser, string>,
        IUserStore<IdentityUser>, IUserStore<IdentityUser, string>, IDisposable, IUserClaimStore<IdentityUser, string>, IUserRoleStore<IdentityUser, string>, IUserPasswordStore<IdentityUser, string>, IQueryableUserStore<IdentityUser, string>
    {
        private readonly IEntities<AspNetUser> users;
    
        private bool _disposed;

        public IdentityUserDataStore()
        {
            //var context = new Db_AutoaccountEntities();
            //context.Configuration.LazyLoadingEnabled = false;
            UnitOfWork unitOfWork = new UnitOfWork();
            users = new Entities<AspNetUser>(unitOfWork);
        }

        public IQueryable<IdentityUser> Users => throw new NotImplementedException();

        public Task AddClaimAsync(IdentityUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task AddLoginAsync(IdentityUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(IdentityUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (!this._disposed)
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(bool disposing)
        {

            this._disposed = true;
        }




        public  Task<IdentityUser> FindAsync(UserLoginInfo login)
        {
            return null;
        }

        public Task<IdentityUser> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public  Task<IdentityUser> FindByIdAsync(string userId)
        {

            var user = users.Find(i=>i.Id==userId);
            if (user != null)
            {
                return Task.FromResult<IdentityUser>( new IdentityUser
                {
                    UserName = user.UserName
                });
            }

            return null;
        }

        public  Task<IdentityUser> FindByNameAsync(string userName)
        {
            var user = users.Find(i=>i.UserName==userName);
            if (user != null)
            {
                return Task.FromResult < IdentityUser > (new IdentityUser(user.Id)
                {
                    UserName = user.UserName
                });
            }

            return  Task.FromResult<IdentityUser>( null);
        }


        public async Task<bool> CheckPasswordAsync(IdentityUser user, string password)
        {
            var pass = SecurePassword.HashPassword(password);
            //  return true;
            //var e = SecurePassword.VerifyPassword(pass, password);
            return await Task.FromResult<bool>( users.IsExcist(u =>(u.UserName == user.UserName )));
        }

        public async Task<IList<Claim>> GetClaimsAsync(IdentityUser user)
        {
            return await Task.FromResult< IList < Claim >>( new List<Claim>());
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        //public async Task<IList<string>> GetRolesAsync(IdentityUser user)
        //{
        //    return await Task.FromResult<IList<string>>( unitOfWork.GetRepository<C_Group>().GetAll().Select(e => e.Group_ID).ToList());
        //}

        public Task<bool> HasPasswordAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(IdentityUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimAsync(IdentityUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(IdentityUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(IdentityUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(IdentityUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(IdentityUser user)
        {
            return null ;

        }
    }
}
