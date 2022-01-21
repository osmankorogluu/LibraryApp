using LibraryApp.Domain.Entities;
using LibraryApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Persistence.Repositories.Entityframework
{
   public class EfUserRepository:EfRepositoryBase<User, LibraryDatabaseContext>, IUserRepository
    {
        //User tablosunu ekle ve diğer alanları uygula
        //Automapper ksımını düzenle 
    }
}
