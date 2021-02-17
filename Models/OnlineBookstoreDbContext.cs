using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    public class OnlineBookstoreDbContext : DbContext
    {
        public OnlineBookstoreDbContext (DbContextOptions<OnlineBookstoreDbContext> options): base (options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
