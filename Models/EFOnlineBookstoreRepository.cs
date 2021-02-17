using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    public class EFOnlineBookstoreRepository : IOnlineBookstoreRepository
    {
        private OnlineBookstoreDbContext _context;

        //Constructor
        public EFOnlineBookstoreRepository(OnlineBookstoreDbContext context)
        {
            _context = context;
        }
        public IQueryable<Book> Books => _context.Books;
    }
}
