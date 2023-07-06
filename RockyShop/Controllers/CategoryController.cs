using Microsoft.AspNetCore.Mvc;

namespace RockyShop.Controllers;

public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}