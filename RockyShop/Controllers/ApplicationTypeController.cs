using Microsoft.AspNetCore.Mvc;
using RockyShop.Data;
using RockyShop.Models;


namespace RockyShop.Controllers;

public class ApplicationTypeController : Controller
{
    private readonly ApplicationDbContext _db;

    public ApplicationTypeController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    // GET
    public IActionResult Index()
    {
        IEnumerable<ApplicationType> objList = _db.ApplicationType;
        return View(objList);
    }
    
    
    // GET - CREATE
    public IActionResult Create()
    {
        return View();
    }
    
    // POST - CREATE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ApplicationType obj)
    {
        _db.ApplicationType.Add(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    
    // GET - EDIT
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        
        var obj = _db.ApplicationType.Find(id);

        if (obj == null)
        {
            return NotFound();
            
        }
        
        return View(obj);
    }
    
    // POST - Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(ApplicationType obj)
    {
        // Валидация на стороне сервера
        if (ModelState.IsValid)
        {
            _db.ApplicationType.Update(obj);
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
        
        var obj = _db.ApplicationType.Find(id);

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
        var obj = _db.ApplicationType.Find(id);

        if (obj == null)
        {
            return NotFound();
        }
        
        _db.ApplicationType.Remove(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
        
    }
}