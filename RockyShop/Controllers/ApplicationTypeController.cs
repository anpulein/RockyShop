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
}