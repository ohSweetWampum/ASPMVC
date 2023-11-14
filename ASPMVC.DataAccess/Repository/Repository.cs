using System;
using ASPMVC.Data;
using ASPMVC.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


//Repository: It’s like a specialized storage area or manager for your data.
//Each repository typically handles all the data operations (like add, update, delete, get)
//for a specific entity or table in the database. For example, a CategoryRepository would manage
//all data interactions with the Category table, and a ProductRepository would do the same for the
//Product table.
namespace ASPMVC.DataAccess.Repository
{
    // Define a generic repository class with type parameter T, where T must be a reference type (class)
    public class Repository<T> : IRepository<T> where T : class
    {
        // Private field to store the database context
        private readonly ApplicationDbContext _db;

        // Internal field to represent the DbSet for the entity of type T
        //The dbSet is a field within the Repository<T> class that represents a DbSet<T> object. In Entity Framework, a DbSet<T> is a representation of an entity set, which corresponds to a table in a relational database.

//        Here's what dbSet does in the code:

//In the constructor of the Repository<T> class, the dbSet field is initialized with _db.Set<T>().
//This line creates an instance of DbSet<T> for the specified entity type T, where T is a class that
//represents a data entity(e.g., a table in a database).
//Throughout the class, methods like Add, Get, GetAll, Remove, and RemoveRange interact with the
//database using this dbSet field. For example, when you call dbSet.Add(entity), it adds the provided
//entity to the DbSet, which in turn represents an operation to add a record to the corresponding table
//in the database.
//In summary, dbSet is an instance of DbSet<T> that serves as a gateway for performing database
//operations (such as adding, querying, or removing records) related to the specified entity type T within
//the repository. It's a fundamental part of Entity Framework and allows developers to interact with the
//database in an object-oriented way.
     
        internal DbSet<T> dbSet;

    // Constructor that takes an instance of ApplicationDbContext (a database context)
        public Repository(ApplicationDbContext db)
        {
            _db = db; // Assign the provided database context to the private field
            this.dbSet = _db.Set<T>(); // Initialize the DbSet for the specified entity type
            //_db.Categories == dbSet
        }

        // Add a new entity to the repository
        public void Add(T entity)
        {
            dbSet.Add(entity); // Add the provided entity to the DbSet
        }

        // Get a single entity from the repository based on a filter expression
        public T Get(Expression<Func<T, bool>> filter)
        {
            //IQueryable<T> is used in your case to represent a queryable collection of data from the database.
            //It enables deferred execution, allowing you to build and compose complex database queries using
            //LINQ expressions before actually fetching the data, which can lead to more efficient and
            //optimized database operations.
            IQueryable<T> query = dbSet; // Create a queryable collection from the DbSet
            //query = query.Where(filter); is a LINQ expression that filters the data in query based on the
            //condition defined in filter, and the result is assigned back to query, potentially narrowing
            //down the data set based on the filter condition.
            query = query.Where(filter); // Apply the provided filter expression to the query
            return query.FirstOrDefault(); // Return the first entity that matches the filter
        }

        // Get all entities of the specified type from the repository
        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet; // Create a queryable collection from the DbSet
            //The ToList() method is a LINQ extension method that is used to execute a query and
            //retrieve the results as a list. In the context of your code, return query.ToList();
            //is used to execute the LINQ query represented by the query variable and retrieve the
            //data as a List<T>.
            return query.ToList(); // Return all entities as a list
        }

        // Remove an entity from the repository
        public void Remove(T entity)
        {
            dbSet.Remove(entity); // Remove the provided entity from the DbSet
        }

        // Remove a collection of entities from the repository
        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity); // Remove a collection of entities from the DbSet
        }
    }
}

