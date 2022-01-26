using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Dto.BookDto
{
   public class BookAddDto
    {
        public int CategoryId { get; set; }
        public string BookName { get; set; }
        public string Writer { get; set; }
        public string Price { get; set; }
        public int NumberPages { get; set; }
        public int Stock { get; set; }
    }
}
