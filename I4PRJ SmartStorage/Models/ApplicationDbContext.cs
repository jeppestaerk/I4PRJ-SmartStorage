﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace I4PRJ_SmartStorage.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {



        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<I4PRJ_SmartStorage.Models.Inventory> Inventories { get; set; }

        public System.Data.Entity.DbSet<I4PRJ_SmartStorage.Models.Supplier> Suppliers { get; set; }
    }
}