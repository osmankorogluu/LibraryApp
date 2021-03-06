using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Persistence.Repositories
{
    public interface IBookImageRepository:IRepository<BookImage>
    {
        void AddRange(List<BookImage> bookImage);
    }
}
