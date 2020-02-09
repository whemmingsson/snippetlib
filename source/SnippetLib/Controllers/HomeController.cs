using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SnippetLib.Business;
using SnippetLib.Models;

namespace SnippetLib.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISnippetRepository _repo;
        private readonly ISnippetFileService _fileService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ISnippetRepository repo, ISnippetFileService service)
        {
            _logger = logger;
            _repo = repo;
            _fileService = service;
        }

        public IActionResult Index()
        {
            var all = _repo.GetAll();

            // Do magic
            return View(all.Select(s => new SnippetViewModel()
            { 
                Snippet = s, 
                SnippetFile = _fileService.ReadSnippet(s.Id)
            }));
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Admin()
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
