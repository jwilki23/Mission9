using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public class EFMission9Repository : IMission9Repository
    {
        private Mission9Context context { get; set; }   
        public EFMission9Repository (Mission9Context temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
