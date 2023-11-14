using System;
using ASPMVC.Models;
using ASPMVC.Models.Models;

namespace ASPMVC.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);

    }
}

