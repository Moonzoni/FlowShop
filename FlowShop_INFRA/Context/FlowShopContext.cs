using System;
using System.Collections.Generic;
using System.Text;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace FlowShop_INFRA.Context
{
    public class FlowShopContext : DbContext
    {
        public FlowShopContext(DbContextOptions<FlowShopContext> dbContextOptions) : base(dbContextOptions) { }
        

        public void SendChanges()
        {
            ChangeTracker.DetectChanges();
            SaveChanges();
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            

        }
    }
}
