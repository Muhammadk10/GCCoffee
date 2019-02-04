using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Lab23.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<userRegistration> UserRegistraion { get; set; }
    }
}