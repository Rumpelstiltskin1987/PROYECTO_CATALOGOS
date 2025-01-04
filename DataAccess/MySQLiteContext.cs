using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MySQLiteContext : DbContext
    {
        public MySQLiteContext(DbContextOptions<MySQLiteContext> options) 
            : base(options) 
        { 
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
