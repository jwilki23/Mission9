using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public interface IMission9Repository
    {
        IQueryable<Book> Books { get; }
    }
}
