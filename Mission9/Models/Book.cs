using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public partial class Book
    {
        [Key]
        [Required]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        public string Classification { get; set; }
        public string Category { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }
    }
}
