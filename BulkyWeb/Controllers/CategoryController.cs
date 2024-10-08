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

        //create action 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]       
        public IActionResult Create(Category obj)// here we take the category from the create/cshtml as the post form
        {
            if(obj.Name==  obj.DisplayOrder.ToString()) // if the name and display order are the same
			{
				ModelState.AddModelError("Name", "Name and Display Order can not be the same");
				return View(obj);
			}
            else
            {
				_db.Categories.Add(obj);
				_db.SaveChanges();
				TempData["message"] = "Successfully";

				return RedirectToAction("Index"); //direct to Index action for the new data to be shown
			}
            
        }

		// edit action
		public IActionResult Edit(int? categoryId) //categoryId ở bên view/ index.cshtml
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }
            Category cate= _db.Categories.Find(categoryId); // cas1
            // case 2 Category cate=_db.Categories.FirstOrDefault(u => u.CategoryId == categoryId); 
            // case 3 Category ? cate = _db.Categories.Where(u => u.Equals(categoryId)).FirstOrDefault(); 
            if (cate==null)
			{
				return NotFound();
			}
            return View(cate);
		}

		[HttpPost]
		public IActionResult Edit(Category obj)// here we take the category from the edit/cshtml as the post form
		{
			if(ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
				TempData["message"] = "Successfully";

				return RedirectToAction("Index");

            }
            return View();

        }

        //delete action
        public IActionResult Delete(int? categoryId) //categoryId ở bên view/ index.cshtml
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }
            Category cate = _db.Categories.Find(categoryId); // cas1
            // case 2 Category cate=_db.Categories.FirstOrDefault(u => u.CategoryId == categoryId); 
            // case 3 Category ? cate = _db.Categories.Where(u => u.Equals(categoryId)).FirstOrDefault(); 
            if (cate == null)
            {
                return NotFound();
            }
            return View(cate);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteAction(Category obj)// here we take the category from the edit/cshtml as the post form
        {
            Category? deleteCategory = _db.Categories.Find(obj.Id);
            if (deleteCategory == null)
            {
                return NotFound();
            }
            else
            {
                _db.Categories.Remove(deleteCategory);
                _db.SaveChanges();
                TempData["message"] = "Successfully";
                return RedirectToAction("Index");
            }
			



        }
    }
}
