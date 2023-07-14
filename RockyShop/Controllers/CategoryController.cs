using Microsoft.AspNetCore.Mvc;
using RockyShop.Data;
using RockyShop.Models;

namespace RockyShop.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    // GET
    public IActionResult Index()
    {
        IEnumerable<Category> objList = _db.Category;
        return View(objList);
    }
}