using System;
using ASPMVC.Data;
using ASPMVC.DataAccess.Repository.IRepository;
using ASPMVC.Models;

namespace ASPMVC.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

     

        public void Update(Category obj)
        {
            _db.myCategoryTable.Update(obj);
        }
    }
}

