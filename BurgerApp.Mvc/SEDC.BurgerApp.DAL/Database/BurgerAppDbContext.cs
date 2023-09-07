using Microsoft.EntityFrameworkCore;
using SEDC.BurgerApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SEDC.BurgerApp.DAL.Database
{
    public class BurgerAppDbContext : DbContext
    {

        public BurgerAppDbContext()
        {
        }

        public BurgerAppDbContext(DbContextOptions<BurgerAppDbContext> options) : base(options)
        {
        }
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
