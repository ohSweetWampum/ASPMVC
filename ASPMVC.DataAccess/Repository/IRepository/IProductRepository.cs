using System;
using ASPMVC.Models;
using ASPMVC.Models.Models;

namespace ASPMVC.DataAccess.Repository.IRepository
{
    //The IProductRepository interface extends the IRepository<Product> interface, inheriting its generic
    //data access methods. It also introduces a specific Update method tailored for product-related
    //operations, providing a specialized interface for managing product data within a repository.
    public interface IProductRepository : IRepository<Product>
    {
        //The Product obj in the void Update(Product obj) method of the IProductRepository interface
        //represents an instance of the Product class. In this context, it is the product object that
        //you want to update within the repository.
        void Update(Product obj);

    }
}

