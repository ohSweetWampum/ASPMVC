using System;
using ASPMVC.Models;
using ASPMVC.Models.Models;
using Microsoft.EntityFrameworkCore;


//# ASP.NET-MVC-application
//# ASP.NET-MVC-application
//make sure sever is running and the databse is connected before doing the below steps
//#add migration from the dataaccess project directory terminal
//# mattgibson@Matts-MacBook-Pro ASP.NET_Practice.DataAccess %dotnet ef migrations add ProductTableAndSeedTable --output-dir Migrations --startup-project ../ASPMVC
//# mattgibson@Matts-MacBook-Pro ASP.NET_Practice.DataAccess % dotnet ef database update --startup-project ../ASPMVC
//check the newly generated cs file in migrations to ensure it is not empty


//# dependency injection service lifetimes types

//#transient: new service created everytime it is requested
//#example:

//#scoped (most reccomended): new service once per request
//#example:


//#singleton: new service once per lifetime of the application
//#example:
namespace ASPMVC.Data
{

    //DbContext is built in class from Entityframework core
    public class ApplicationDbContext : DbContext
    {
        //DbSet is built in. should be of type Category(catergory class type)
        //to migrate the table and create it  in db, run cmmd dotnet ef migrations add [nameofmigration], will also
        //create a migrations folder,
        //then run dotnet ef database update, to apply migration
        public DbSet<Category> myCategoryTable { get; set; }

        public DbSet<Product> myProductTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Product>().HasData(
                 new Product
                 {
                     Id = 1,
                     Title = "Fortune of Time",
                     Author = "Billy Spark",
                     Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                     ISBN = "SWD9999001",
                     CategoryId = 1,
                     ListPrice = 99,
                     Price = 90,
                     Price50 = 85,
                     Price100 = 80,
                     imageURL = ""
                 },
                 new Product
                 {
                     Id = 2,
                     Title = "Dark Skies",
                     Author = "Nancy Hoover",
                     Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                     ISBN = "CAW777777701",
                     CategoryId = 3,
                     ListPrice = 40,
                     Price = 30,
                     Price50 = 25,
                     Price100 = 20,
                     imageURL = ""
                 },
                 new Product
                 {
                     Id = 3,
                     Title = "Vanish in the Sunset",
                     Author = "Julian Button",
                     Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                     ISBN = "RITO5555501",
                     CategoryId = 2,
                     ListPrice = 55,
                     Price = 50,
                     Price50 = 40,
                     Price100 = 35,
                     imageURL = ""
                 },
                 new Product
                 {
                     Id = 4,
                     Title = "Cotton Candy",
                     Author = "Abby Muscles",
                     Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                     ISBN = "WS3333333301",
                     CategoryId = 1,
                     ListPrice = 70,
                     Price = 65,
                     Price50 = 60,
                     Price100 = 55,
                     imageURL = ""
                 },
                 new Product
                 {
                     Id = 5,
                     Title = "Rock in the Ocean",
                     Author = "Ron Parker",
                     Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                     ISBN = "SOTJ1111111101",
                     CategoryId = 2,
                     ListPrice = 30,
                     Price = 27,
                     Price50 = 25,
                     Price100 = 20,
                     imageURL = ""
                 },
                 new Product
                 {
                     Id = 6,
                     Title = "Leaves and Wonders",
                     Author = "Laura Phantom",
                     Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                     ISBN = "FOT000000001",
                     CategoryId = 3,
                     ListPrice = 25,
                     Price = 23,
                     Price50 = 22,
                     Price100 = 20,
                     imageURL = ""
                 }
                 );
        }

        //DbContdddextOptions is a built in class, it is of generic type (<>)    ApplicationDbContext   
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }

}