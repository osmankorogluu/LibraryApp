using LibraryApp.Application.Dto.BookDto;
using LibraryApp.Domain.Entities;
using LibraryApp.Persistence.Result.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAll();
        Task<IResult> AddAsync(BookAddDto bookAddDto);
        Task<IResult> DeleteAsync(BookDto bookDto);
        Task<IResult> UpdateAsync(BookUpdateDto bookUpdateDto);
    }
}
