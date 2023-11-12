
using ClassLibrary;
using Deploy_f.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Deploy_f.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExampleDbContext _exampleDbContext;

        public HomeController(ILogger<HomeController> logger, ExampleDbContext exampleDbContext)
        {
            _logger = logger;
            _exampleDbContext = exampleDbContext;            
        }

        public IActionResult Index()
        {
            var entities = _exampleDbContext.SomeEntity.ToArray();
            return Json(entities);            
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

        [HttpGet("{name}")]
        public IActionResult Create(string name)
        {
            var entity = new SomeEntity()
            {
                Name = name
            };
            _exampleDbContext.Add(entity);
            _exampleDbContext.SaveChanges();            
            return Json(entity);
        }
    }
}