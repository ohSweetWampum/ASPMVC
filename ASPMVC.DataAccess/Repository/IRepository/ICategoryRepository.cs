using System;
using ASPMVC.Models;

namespace ASPMVC.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
      
    }
}

