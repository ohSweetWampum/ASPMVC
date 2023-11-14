using System;
using System.Linq.Expressions;
using Humanizer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

//why Use Interfaces: Interfaces for repositories, like ICategoryRepository and IProductRepository,
//define a contract or set of rules that each repository must follow. This has several advantages:

//Abstraction: The interface abstracts the implementation details of the repository.
//This means you can change the underlying code of the repository without affecting the rest of your
//application, as long as the interface stays the same.

//Testing: With interfaces, it’s easier to create mock repositories for testing purposes.
//You can test other parts of your application using these mocks without needing a real database.

//Flexibility and Maintainability: If you need to change the data source or the way you interact
//with the database, you can do so by simply creating a new repository implementation that follows
//the same interface.

//In summary, in your code, repositories are used to manage database operations for specific entities,
//and interfaces define a consistent set of operations that these repositories must implement,
//providing abstraction, ease of testing, and flexibility.
namespace ASPMVC.DataAccess.Repository.IRepository
{


    //In software development, particularly when dealing with databases and Object-Relational Mapping (ORM)
    //frameworks like Entity Framework, an "entity" typically refers to a class that represents a table or
    //row in a database. Here's a simplified explanation:

//Database Representation: An entity is a software object that maps to a table in a database.For example,
//if you have a Customer table in your database, you would typically have a corresponding Customer entity
//in your code.

//Row Correspondence: Each instance of an entity represents a row in the corresponding database table.
//So, a single Customer object would represent one customer's data as stored in a single row of the Customer
//table.

//Properties as Columns: The properties of the entity class correspond to the columns of the table.
//For instance, if your Customer table has columns like Id, Name, and Email, your Customer entity would also
//have Id, Name, and Email properties.

    // Define a generic interface named IRepository with a type parameter T, where T is restricted to be a class.
    public interface IRepository<T> where T : class
    {
        // Define a method to get all entities of type T. For example, if T is Category,
        // this method returns all categories.
        //Using IEnumerable<T> in the IRepository<T> interface provides flexibility and performance benefits.
        //It allows deferred execution, supports read-only access to data, and abstracts over various
        //collection types, making it suitable for querying and iterating over data, especially in
        //scenarios like database access where lazy loading and LINQ queries are common.
        //It also promotes compatibility with data access frameworks like Entity Framework.
     
        IEnumerable<T> GetAll();

        // Define a method to get a single entity of type T based on a specified condition
        // (expressed as a lambda expression).
        // For example, you can retrieve a specific category by its ID or name.
        //The code snippet T Get(Expression<Func<T, bool>> filter); represents a method that accepts a
        //lambda expression as a filter criterion. When you call this method, you provide a lambda
        //expression that defines a condition, allowing you to retrieve items of type T that match the
        //specified criteria, such as retrieving customers older than 18 in a collection of customers.
       
        T Get(Expression<Func<T, bool>> filter);

        // Define a method to add a new entity of type T to the repository.
        // For example, adding a new Category instance to the repository.
        void Add(T entity);

        // Define a method to remove an existing entity of type T from the repository.
        // For example, removing a specific Category instance from the repository.
        void Remove(T entity);

        // Define a method to remove a range of entities of type T from the repository.
        // This is useful for deleting multiple entities at once, like a batch of Categories.
        void RemoveRange(IEnumerable<T> entity);
    }

}


