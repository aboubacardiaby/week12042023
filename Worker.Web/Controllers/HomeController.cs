using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Worker.Data.Entities;
using Worker.Web.Data;
using Worker.Web.Models;

namespace Worker.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WorkerDataContext _context;

        public HomeController(ILogger<HomeController> logger, WorkerDataContext context)
        {
            _logger = logger;
            this._context = context;
        }

        public IActionResult Index()
        {
            var query = _context.tblCustomer.ToList();
            return View(query);
        }

        public IActionResult Privacy()
        {
            var custquery = _context.tblCustomer.ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}