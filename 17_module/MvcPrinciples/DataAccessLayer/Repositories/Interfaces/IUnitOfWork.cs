using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<CategoryEntity> Categories { get; }
        IRepository<ProductEntity> Products { get; }
        void Save();
    }
}
