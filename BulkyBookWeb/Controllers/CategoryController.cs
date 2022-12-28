using BulkyBookWeb.Data;
using BulkyBookWeb.Migrations;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var objCategoryList = _db.Categories.ToList();  
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {            
            return View();
        }
        //POST
        [HttpPost]
        public IActionResult Create(Category cat)
        {
            if(cat.CategoryName == cat.DisplayOrder.ToString())
            {
                ModelState.AddModelError("categoryname", "Category Name should not match Display Order");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat);
        }
    }
}
