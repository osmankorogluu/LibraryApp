using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Persistence.UnitOfWorks
{
   public interface UnitOfWorks: IDisposable
    {
        bool Commit(bool state = true);
    }
}
