using LibraryApp.Domain.Entities;
using LibraryApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Persistence.Repositories.Entityframework
{
    public class EfBookImageRepository: EfRepositoryBase<BookImage, LibraryDatabaseContext>,IBookImageRepository
    {
        public EfBookImageRepository(LibraryDatabaseContext libraryDatabaseContext) : base(libraryDatabaseContext)
        {

        }
        public void AddRange(List<BookImage>bookImages)
        {
            using (LibraryDatabaseContext context = new LibraryDatabaseContext())
            {
                context.BookImages.AddRange(bookImages);
                context.SaveChanges();
            }
        }
    }
}
