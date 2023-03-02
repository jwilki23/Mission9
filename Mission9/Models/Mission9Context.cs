using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace Mission9.Models
{
    public class Mission9Context : DbContext
    {
        public Mission9Context()
        {
        }
        public Mission9Context(DbContextOptions<Mission9Context> options)
            : base(options)
        { }

        public DbSet<Book> Books { get; set; }
    }
}
