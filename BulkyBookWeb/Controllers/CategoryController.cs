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
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)            
                return NotFound();            
            var catFromDB = _db.Categories.Find(id);
            if(catFromDB == null)            
                return NotFound();
            
            return View(catFromDB);
        }
        //POST
        [HttpPost]
        public IActionResult Edit(Category cat)
        {
            if (cat.CategoryName == cat.DisplayOrder.ToString())
            {
                ModelState.AddModelError("categoryname", "Category Name should not match Display Order");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat);
        }
        //[HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
                var cat = _db.Categories.Find(id);
                if (cat == null)
                    return NotFound();
            if (ModelState.IsValid)
            {
                _db.Categories.Remove(cat);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
