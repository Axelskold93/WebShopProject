using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebShop.Models;

namespace WebShop.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
