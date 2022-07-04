using Microsoft.EntityFrameworkCore;
using QRMenu.CmsManagement.Core.Domain.Entities;
using QRMenu.CmsManagement.Core.Domain.Entities.Nn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Infrastructure.Persistence.Context
{
    public class QRMenuContext : DbContext
    {
        public QRMenuContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //İlişkisel tabloların eylem tiplerini belirttik delete,update,create sonucunda herhangi bir eylem yapma
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            modelBuilder.Entity<CategoryProducts>().HasKey(x => new { x.CategoryId, x.ProductId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Logger> Logger { get; set; }
        public DbSet<CategoryProducts> CategoryProducts { get; set; }
    }
}
