using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Repository.ModelRepository
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
