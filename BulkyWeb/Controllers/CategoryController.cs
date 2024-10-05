using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        // use dependency injection to get data from database and add it to Index view 
        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
              _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList= _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)// here we take the category from the create/cshtml as the post form
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return Redirect("Index"); //direct to Index action for the new data to be shown
        }
    }
}
