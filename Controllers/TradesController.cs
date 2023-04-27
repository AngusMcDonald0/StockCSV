using Microsoft.AspNetCore.Mvc;

namespace StockCSV.Controllers
{
    public class TradesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
