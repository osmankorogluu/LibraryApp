﻿using LibraryApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Entities
{
    public class BookImage:BaseEntity
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }

    }
}
