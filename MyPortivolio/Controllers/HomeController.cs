using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyPortivolio.Data;
using MyPortivolio.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortivolio.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly MyPortivolioContext _context;
        private readonly ILogger<HomeController> _logger;
       // private readonly IWebHostEnvironment _webHost;

        public HomeController(MyPortivolioContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            await _context.SaveChangesAsync();
            return View();
        }

        public async Task<IActionResult> Works()
        {
            await _context.SaveChangesAsync();
            return View();
        }

        public async Task<IActionResult> About()
        {
            await _context.SaveChangesAsync();
            return View();
        }

        public IActionResult Pages()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadFile(Project files)
        {
            using (var memorySystem = new MemoryStream())
            {
                await files.FileDocs.CopyToAsync(memorySystem);

                // Upload the file
                if (memorySystem.Length < 2097152)
                {
                    _context.projects.Add(files);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
                RedirectToAction("UploadFile");
            }
            return View(files);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
