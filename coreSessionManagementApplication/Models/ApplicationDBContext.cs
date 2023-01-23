using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace coreSessionManagementApplication.Models
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<Orderdetails> orderdetails { get; set; }

        public DbSet<Product> Products { get; set; }
        //public DbSet<PizzaView> PizzaViews { get; set; }
        public DbSet<order> orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=H5CG125CW45;Database=JoesPizzaDB;Integrated Security=true;");
        }
    }
}
