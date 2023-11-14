using System;
using ASPMVC.Data;
using ASPMVC.DataAccess.Repository.IRepository;

namespace ASPMVC.DataAccess.Repository
{

    // Define a class named UnitOfWork that implements the IUnitOfWork interface.
    public class UnitOfWork : IUnitOfWork
    {
        // A private field to hold the database context.
        private ApplicationDbContext _db;

        // Public property of type ICategoryRepository. It's accessible outside the class but can only be set within the class.
        public ICategoryRepository Category { get; private set; }

        // Public property of type IProductRepository. It's accessible outside the class but can only be set within the class.
        public IProductRepository Product { get; private set; }

        // Constructor for the UnitOfWork class, taking an ApplicationDbContext as a parameter.
        public UnitOfWork(ApplicationDbContext db)
        {
            // Set the private field _db with the provided database context.
            _db = db;

            // Instantiate CategoryRepository with the database context and assign it to the Category property.
            Category = new CategoryRepository(_db);

            // Instantiate ProductRepository with the database context and assign it to the Product property.
            Product = new ProductRepository(_db);
        }
        //This class, UnitOfWork, serves as a central point to manage different repository instances and
        //database transactions, ensuring they are all coordinated and committed together.
        //The Save method commits changes across all repositories by calling SaveChanges on the shared
        //database context.

        // Method to save changes to the database.
        public void Save()
        {
            // Call SaveChanges on the database context to save all changes made in this context to the database.
            _db.SaveChanges();
        }
    }
}