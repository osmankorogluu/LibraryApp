using LibraryApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Entities
{
    public class Category : BaseEntity
    {
        // eevt 
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
    }
}
