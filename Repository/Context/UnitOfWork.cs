using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMax.Dal.Context
{
    public class UnitOfWork : DbContext
    {
        static UnitOfWork()
        {
            Database.SetInitializer<UnitOfWork>(null);
        }

        public UnitOfWork()
            : base("Name=VanSalesDbModelEntities")
        {
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
        // Add tables here!
    }
}
