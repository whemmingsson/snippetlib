using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SnippetLib.Business;
using SnippetLib.Business.Extensions;
using SnippetLib.Models;
using SnippetLib.Models.ViewModels;

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

        public IActionResult Create(SnippetForm form)
        {
            return View(form);
        }

        [HttpPost]
        public IActionResult Create(SnippetForm form, IFormFile SnippetFile)
        {
            if(!ModelState.IsValid)
            {
                return View(form);
            }

            if(SnippetFile != null && string.IsNullOrWhiteSpace(form.Snippet))
            {
                form.Snippet = SnippetFile.ReadString();

            }

            return View(form);
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
