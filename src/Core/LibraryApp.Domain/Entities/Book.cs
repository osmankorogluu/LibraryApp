using LibraryApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Entities
{
    public class Book : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Writer { get; set; }
        public string Price { get; set; }
        public int NumberPages { get; set; }
        public int Stock { get; set; }
    }
}

