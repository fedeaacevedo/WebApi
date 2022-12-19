using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Productos()
        {
            return View();
        }
    }
}
