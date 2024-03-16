using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() 
        {
            return View(); // Trả về view có cùng tên với nó
        }

        public IActionResult Crivacy()
        {
            return View(); 
        }
        public IActionResult Adu()
        {
            return View();// Trả về - trỏ đến View có tên là Adu (cùng tên với Action)
            // return Content("Xin chào các streamer đến với trải nghiệm...");
            // return NoContent();
            // return NotFound();
        }
        public IActionResult DieuHuong()
        {
            // Thực hiện hành vi nào đó trước đi
            return RedirectToAction("Index"); // Thực hiện điều hướng đến Action nào đó 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}