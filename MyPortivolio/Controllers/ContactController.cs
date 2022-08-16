using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortivolio.Data;
using MyPortivolio.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortivolio.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly MyPortivolioContext context;
        public ContactController(MyPortivolioContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(Contacts list)
        {

            if (ModelState.IsValid)
            {
                context.Add(list);
                await context.SaveChangesAsync();
                return RedirectToAction("Contact");
            }
            return View(list);
        }
        public async Task<IActionResult> ViewProject()
        {
            IQueryable<Project> works = from i in context.projects orderby i.Id select i;
            List<Project> myProjects = await works.ToListAsync();

            return View(myProjects);
        }
        // Get to do

        public IActionResult Create() => View();

        // Post Create page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
            if (ModelState.IsValid)
            {
                context.Add(project);
                await context.SaveChangesAsync();

                TempData["Success"] = "The Item has been added";
                return RedirectToAction("ViewProject");
            }
            return View(project);
        }

        // Edit Get
        public async Task<IActionResult> Edit(int id)
        {
            Project project = await context.projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }
        // Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                context.Update(project);
                await context.SaveChangesAsync();

                TempData["Success"] = "The Item has been updated";
                return RedirectToAction("ViewProject");
            }
            return View(project);
        }

        // Delete post
        public async Task<IActionResult> Delete(int id)
        {
            Project project = await context.projects.FindAsync(id);
            if (project == null)
            {
                TempData["Error"] = "Item its not exit";
            }
            else
            {
                context.projects.Remove(project);
                await context.SaveChangesAsync();
                TempData["Success"] = " Item has been deleted";

            }

            return RedirectToAction("ViewProject");
        }
        // Delete All
        public async Task<IActionResult> DeleteAll(Project project )
        {
            if (project == null)
            {
                TempData["Error"] = "No items in Database";
            }
            else
            {
                context.projects.RemoveRange(context.projects);
                await context.SaveChangesAsync();
                TempData["Success"] = "All items in Database deleted";
            }

            return RedirectToAction("ViewProject");
        }
    }
}
