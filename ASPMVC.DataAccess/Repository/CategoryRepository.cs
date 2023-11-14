using System;
using ASPMVC.Data;
using ASPMVC.DataAccess.Repository.IRepository;
using ASPMVC.Models;

namespace ASPMVC.DataAccess.Repository
{
    // Define a class called CategoryRepository that inherits from Repository<Category> and implements
    // ICategoryRepository
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        // Constructor that takes an instance of ApplicationDbContext and calls the base constructor with it
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db; // Assign the provided database context to the private field
        }

        // Define a custom method named Update that takes a Category object as a parameter
        public void Update(Category obj)
        {
            // Use the database context (_db) to update the Category object in the "myCategoryTable"
            //The "database context" (ApplicationDbContext) is an integral part of Entity Framework,
            //serving as the bridge between a C# application and a relational database. It manages
            //connections, provides access to database tables through DbSet properties, and enables the
            //execution of LINQ queries, making it essential for data access and manipulation in
            //Entity Framework-based applications.
            _db.myCategoryTable.Update(obj);
        }
    }
}

