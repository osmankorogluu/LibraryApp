using FluentValidation;
using LibraryApp.Domain.Entities;
using LibraryApp.Infrastructure.Utilities;
using LibraryApp.Persistence.Businesss;
using LibraryApp.Persistence.Repositories;
using LibraryApp.Persistence.Result.ComplexTypes;
using LibraryApp.Persistence.Result.Concrete;
using LibraryApp.Persistence.Result.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Interfaces.Manager
{
    public class BookImageManager:IBookImageService
    {
        private readonly IBookImageRepository _bookImageDal;

        public BookImageManager(IBookImageRepository bookImageDal)
        {
            _bookImageDal = bookImageDal;
        }


       
        public IResult Add(BookImage bookImage, IFormFile file)
        {
            var result = BusinessRules.Run(CheckIfImageLimitExceded(bookImage.BookId));
            if (result != null)
            {
                return result;
            }

            var respond = CloudinaryAdapter.UploadPhoto(file);
            bookImage.Date = DateTime.Now;
            bookImage.ImageUrl = respond;
            _bookImageDal.Add(bookImage);
            return new Result(ResultStatus.Success, messages: $"Başarıyla Eklendi");
        }

      
        public IResult AddRange(int bookId, List<IFormFile> file)
        {
            List<BookImage> carImages = new List<BookImage>();
            foreach (IFormFile x in file)
            {
                var respond = CloudinaryAdapter.UploadPhoto(x);
                carImages.Add(new BookImage()
                {
                    Date = DateTime.UtcNow,
                    BookId = bookId,
                    ImageUrl = respond
                });
            }
            _bookImageDal.AddRange(carImages);
            return new Result(ResultStatus.Success, messages: $"Başarıyla Eklendi");
        }

        public IResult Delete(BookImage carImage)
        {
            _bookImageDal.Delete(carImage);
            return new Result(ResultStatus.Success, messages: $"Başarıyla Eklendi");
        }

        
        public IDataResult <List<BookImage>> GetAll()
        {
            // new SuccessDataResult<List<Book>>(_bookImageDal.GetAlls());
            return null;
        }
        public IDataResult<List<BookImage>> GetAllByBookId(int bookId)
        {
            return null;
        }


        public IDataResult<BookImage> GetById(int id)
        {
            //return new SuccessDataResult<BookImage>(_bookImageDal.Gets(i => i.Id == id));
            return null;
        }

        
        public IResult Update(BookImage bookImage)
        {
            var result = BusinessRules.Run(CheckIfImageLimitExceded(bookImage.BookId));
            if (result != null)
            {
                return result;
            }

            _bookImageDal.Update(bookImage);
            return new Result(ResultStatus.Success, messages: $"Başarıyla Eklendi");
        }

       
        public IResult DeleteById(int id)
        {
            var image = _bookImageDal.Get(i => i.Id == id);
           

            _bookImageDal.Delete(image);
            return new Result(ResultStatus.Success, messages: $"Başarıyla Eklendi");
        }

        private IResult CheckIfImageLimitExceded(int bookId)
        {
            var result = _bookImageDal.GetAlls(c => c.BookId == bookId).Count;


            return new Result(ResultStatus.Success, messages: $"Başarıyla Eklendi");
        }

        private IResult CheckIfCarHasAnyImage(int bookId)
        {
            var result = _bookImageDal.GetAlls(c => c.BookId == bookId).Any();


            return new Result(ResultStatus.Success, messages: $"Başarıyla Eklendi");
        }

      
    }
}

