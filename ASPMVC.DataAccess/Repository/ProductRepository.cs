using System;
using ASPMVC.Data;
using ASPMVC.DataAccess.Repository.IRepository;
using ASPMVC.Models;
using ASPMVC.Models.Models;

namespace ASPMVC.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Product obj)
        {
            _db.myProductTable.Update(obj);
        }
    }
}

