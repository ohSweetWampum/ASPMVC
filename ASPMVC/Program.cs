using System.IO;
using System.Reflection.Metadata;
using System.Security.Policy;
using ASPMVC.Data;
using ASPMVC.DataAccess.Repository;

using ASPMVC.DataAccess.Repository.IRepository;

using Microsoft.EntityFrameworkCore;


namespace ASPMVC;

public class Program
{
    public static void Main(string[] args)
    {


    //////In the context of ASP.NET Core and many modern software frameworks, a "builder" is a design pattern
    //used to simplify the creation and configuration of complex objects or systems. In your code snippet,
    //the builder is specifically an instance of WebApplicationBuilder, which is part of the
    //ASP.NET Core framework. Here's a breakdown of what it does:

    /////a "builder" in software development is like a helper tool that assists in putting together a
    //complex object or system, much like how a construction manual helps in assembling a complicated
    //piece of furniture. It guides you through the steps needed to set up your application correctly,
    //handling the complex details behind the scenes. In your ASP.NET Core code, the builder is used
    //to configure and prepare your web application before it starts running, setting up things like
    //database connections, services, and how your app will handle web requests.

    //////Builder: This is a broad term and, in the context of software like ASP.NET Core, refers to a tool that
    //helps set up your application. It's like a construction manager who oversees and coordinates various
    //aspects of a building project. In your app, the builder sets up the environment, deciding what
    //components (like services) will be used and how they will work together.

    //////Services: These are more specific and relate to particular tasks or functions in your application,
    //much like specialized workers on a construction site.Each service has a specific job - for example,
    //one service might handle saving and retrieving data from a database, another might manage user logins,
    //and so on.The builder coordinates these services, making sure they're available and set up correctly for
    //your application to use when needed.


        // Create a builder for the web application, initializing it with command-line arguments.
            var builder = WebApplication.CreateBuilder(args);




        // Add MVC controller and view services to the application's service container.
        builder.Services.AddControllersWithViews();

        // Add a database context (ApplicationDbContext) to the service container with options 
        // to use SQL Server. The connection string is retrieved from the application's configuration.
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Register the UnitOfWork class as a scoped service of type IUnitOfWork. 
        // This means a new instance of UnitOfWork will be created for each request.
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Build the web application using the configurations defined above.
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        // Check if the application is not running in the Development environment.
        if (!app.Environment.IsDevelopment())
        {
            // If not in Development, use a custom error handler for exceptions, directing to "/Home/Error".
            app.UseExceptionHandler("/Home/Error");

            // Enable HTTP Strict Transport Security (HSTS), which is a web security policy
            // that helps protect against protocol downgrade attacks and cookie hijacking.
            app.UseHsts();
        }

        // Adds middleware to the pipeline that redirects HTTP requests to HTTPS, enhancing security.
        app.UseHttpsRedirection();

        // Adds middleware that enables serving static files (like images, CSS, JavaScript) from a directory.
        app.UseStaticFiles();

        // Adds middleware to the pipeline that enables routing capabilities, 
        // allowing the application to match incoming requests to routes.
        app.UseRouting();

        // Adds middleware for authorization, enabling the application to enforce 
        // authorization rules on routes and actions.
        app.UseAuthorization();

        //the below code sets up the structure of how the routes should be, here the default route,
        //specifies go to {area=Customer}/{controller=Home}/{action=Index}/{id?}, "Customer" is the default
        //area if unspecified, "Home" is the default controller, "Index" is the default action,
        //and the id parameter is optional, allowing the route to match URLs with or without an ID.
        //these values are overwritten when you specify different values such as here in the create.cshtml:
        //  <a asp-controller="Category" asp-action="Index" class="btn btn-outline-primary border  form-control">
        //Back to List</a>, when this link/button is clicked then the convential route is/would be:
        //  /Customer/Category/Index
        app.MapControllerRoute(
            name: "default",
            pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");


        //starts app
        app.Run();
    }
}

