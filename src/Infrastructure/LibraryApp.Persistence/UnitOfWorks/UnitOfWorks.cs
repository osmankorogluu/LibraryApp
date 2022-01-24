using LibraryApp.Persistence.Repositories.Entityframework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Persistence.UnitOfWorks
{
    public class UnitofWork
    {
        //    private readonly Northwind _context;
        //    public EfRepositoryBase efRepositoryBase;
        //    public UnitofWork()
        //    {
        //        this._context = new Northwind();
        //    }
        //    public CategoryRepository CategoryRepository => this.categoryRepository ?? (this.categoryRepository = new CategoryRepository(_context));
        //    public void Save()
        //    {
        //        try
        //        {
        //            using (var transaction = _context.Database.BeginTransaction())
        //            {
        //                try
        //                {
        //                    _context.SaveChanges();
        //                    transaction.Commit();
        //                }
        //                catch
        //                {
        //                    transaction.Rollback();
        //                    throw;
        //                }
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            //TODO:Logging
        //        }
        //    }
        //    private bool disposed = false;
        //    protected virtual void Dispose(bool disposing)
        //    {
        //        if (!this.disposed)
        //        {
        //            if (disposing)
        //            {
        //                _context.Dispose();
        //            }
        //        }
        //        this.disposed = true;
        //    }
        //    public void Dispose()
        //    {
        //        Dispose(true);
        //        GC.SuppressFinalize(this);
        //    }
        //}
    }
}
