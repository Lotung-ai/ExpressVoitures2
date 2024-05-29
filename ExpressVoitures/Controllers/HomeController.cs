using ExpressVoitures.Data;
using ExpressVoitures.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace ExpressVoitures.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> IndexProto()
        {
            var applicationDbContext = _context.Cars.Include(c => c.Brand).Include(c => c.Finition).Include(c => c.Modele).Include(c => c.Year);
            return View(await applicationDbContext.ToListAsync());
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cars()
        {
            return RedirectToAction("Index", "Cars");
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
