using System;
using ASPMVC.Models;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }

        //DbContextOptions is a built in class, it is of generic type (<>)    ApplicationDbContext   
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }

}