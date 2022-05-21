using LibraryApp.Domain.Entities;
using LibraryApp.Persistence.Result.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Interfaces
{
    public interface IBookImageService
    {
        IDataResult< List<BookImage>> GetAll();
        IDataResult <BookImage> GetById(int id);
        IDataResult <List<BookImage>> GetAllByBookId(int bookId);
        IResult Add(BookImage bookImage, IFormFile file);
        IResult AddRange(int bookId, List<IFormFile> file);
        IResult Delete(BookImage bookImage);
        IResult Update(BookImage bookImage);
        IResult DeleteById(int id);
    }
}
