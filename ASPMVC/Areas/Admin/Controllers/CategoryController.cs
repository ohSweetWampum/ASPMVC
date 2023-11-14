using System;
using ASPMVC.Data;
using ASPMVC.DataAccess.Repository.IRepository;
using ASPMVC.Models;
using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


//contollers are where the HTTP requests are handled (their logic)

//ASP.NET MVC uses convention based routing, which means he routes are determined based on the controller and action
//names. For instance, a request to /Category/Index would be directed to the Index action method of the CategoryController.
//You don't have to explicitly define the route in each action method because the framework uses these conventions to figure
//out which method to call.

namespace ASPMVC.Areas.Admin.Controllers
{
    // This attribute specifies that this controller is part of the "Admin" area in the MVC application.
    //Specifying the [Area("Admin")] attribute in a controller is necessary to correctly route requests to
    //that controller within a specific segment (or "area") of a larger ASP.NET Core MVC application.
    [Area("Admin")]

    //CategoryController inherits properties and methods from the Controller class
    public class CategoryController : Controller
    {
        // Properties////////////////////////////////////////////////////
        // to hold an instance of IUnitOfWork, used for database operations.
        //_unitOfWork is the name of the variable, and IUnitOfWork is its type.
        //readonly suggests that its value can only be set during the initialization phase,
        //such as in a constructor, and cannot be changed afterwards.

        //unitofwork concept:///

        //The Unit of Work pattern in software development is a way to group together multiple operations
        //that need to be executed as a single unit, often in the context of database transactions.
        //It ensures that either all operations succeed together or, if any operation fails,
        //the entire set is rolled back, maintaining data integrity and consistency.
        //This pattern is commonly used alongside the Repository pattern to abstract and manage database
        //operations more effectively, providing a clear and organized approach to handling data-related tasks.
        private readonly IUnitOfWork _unitOfWork;

        // Constructor////////////////////////////////////////////////////
        // that takes an IUnitOfWork instance. This follows the Dependency Injection pattern.

        //Dependency injection:////
        //n your e-commerce app, you have a CategoryController class. This class needs to perform operations
        //like adding, updating, or deleting categories. To do these operations, it needs access to the
        //database, which is represented by the IUnitOfWork interface in your code.

// Without Dependency Injection:///// Without DI, the CategoryController would create its own instance of
//IUnitOfWork, tightly coupling it with a specific implementation of the database operations.
//This would make it harder to change or test the database logic separately from the controller logic.

//With Dependency Injection:/// Your code demonstrates DI. The CategoryController doesn't create an IUnitOfWork
//instance itself. Instead, an IUnitOfWork instance is provided (injected) to it through its constructor.
//This way, the CategoryController is not responsible for knowing how to create and manage the IUnitOfWork;
//it just knows how to use it. This separation makes your controller more flexible and easier to test.

//Real-World Analogy: /////Think of the CategoryController as a manager in a store who needs various reports
//(like sales, inventory, etc.). Instead of creating these reports themselves
//(which would require detailed knowledge of the entire store's operation),
//the manager receives these reports from different departments (like the sales department, warehouse, etc.).
//This is similar to how the CategoryController receives the IUnitOfWork to interact with the database without
//needing to know the details of database operations.

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //methods/////////////////////////////////////////////////////
        // Action method to handle the default view of the controller. It shows a list of categories.
        public IActionResult Index()
        {
            // Retrieve all categories from the database and convert them to a List.
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();

            // Return the Index view, passing the list of categories to it.
            return View(objCategoryList);
        }

        // Action method to return the view for creating a new category.
        public IActionResult Create()
        {
            // Simply return the Create view.
            return View();
        }

        // This attribute indicates that this action method responds to HTTP POST requests.
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            // Check if the category's name is the same as its display order.
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                // If they are the same, add a validation error to the ModelState.
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            // Check if the model state is valid (i.e., all validation checks passed).
            if (ModelState.IsValid)
            {
                // Add the new category to the database.
                _unitOfWork.Category.Add(obj);
                // Save the changes to the database.
                _unitOfWork.Save();
                // Store a success message in TempData for display after redirection.
                TempData["success"] = "Category created successfully";
                // Redirect to the Index action.
                return RedirectToAction("Index");
            }

            // If the model state is not valid, return the Create view again with the current data.
            return View();
        }

        // Action method for returning the Edit view for a specific category.
        public IActionResult Edit(int? id)
        {
            // Check if the provided id is null or zero, which are invalid.
            if (id == null || id == 0)
            {
                // If so, return a NotFound result.
                return NotFound();
            }

            // Retrieve the category from the database by id.
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);

            // Check if the category was not found in the database.
            if (categoryFromDb == null)
            {
                // If not found, return a NotFound result.
                return NotFound();
            }

            // If found, return the Edit view with the category data.
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
         

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
    }
}

