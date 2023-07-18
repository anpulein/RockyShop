using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RockyShop.Data;
using RockyShop.Models;

namespace RockyShop.Controllers;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _db;

    public ProductController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET
    public IActionResult Index()
    {
        IEnumerable<Product> objList = _db.Product;

        foreach (var obj in objList)
        {
            obj.Category = _db.Category.FirstOrDefault(u => u.Id == obj.CategoryId);
        }
        
        return View(objList);
    }


    // GET - UPSERT
    public IActionResult UpSert(int? id)
    {
        IEnumerable<SelectListItem> CateroryDropDown = _db.Category.Select(s => new SelectListItem 
        {
            Text = s.Name,
            Value = s.Id.ToString()
        });
        
        ViewBag.CateroryDropDown = CateroryDropDown;
        
        Product product = new Product();

        if (id == null)
        {
            // this is for create
            return View(product);
        }
        else
        {
            product = _db.Product.Find(id);
            if (product == null) return NotFound();
            
            return View(product);
        }
    }

    // POST - UPSERT
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UpSert(Category obj)
    {
        // Валидация на стороне сервера
        if (ModelState.IsValid)
        {
            _db.Category.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(obj);
    }
    
    
    // GET - DELETE
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        
        var obj = _db.Category.Find(id);

        if (obj == null)
        {
            return NotFound();
            
        }
        
        return View(obj);
    }
    
    // POST - DELETE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var obj = _db.Category.Find(id);

        if (obj == null)
        {
            return NotFound();
        }
        
        _db.Category.Remove(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
        
    }
}