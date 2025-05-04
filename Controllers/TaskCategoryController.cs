using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoTracker.Data;
using TodoTracker.Models;
using TodoTracker.ViewModels;

namespace TodoTracker.Controllers
{
    public class TaskCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TaskCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        public ActionResult Create()
        {
            return View(new TaskCategoryViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskCategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var category = new TaskCategory
                {
                    CategoryName = vm.CategoryName
                };
                _context.Categories.Add(category);
                _context.SaveChanges();
                //return RedirectToAction("Index", "Task");
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
                return NotFound();

            var vm = new TaskCategoryViewModel
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
            return View(vm);
        }

        // POST: /TaskCategory/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskCategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var category = _context.Categories.Find(vm.Id);
                if (category == null)
                    return NotFound();

                category.CategoryName = vm.CategoryName;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: /TaskCategory/Delete/{id}
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: /TaskCategory/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
                return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Details view
        public IActionResult Details(int id)
        {
            var category = _context.Categories.Include(c => c.Tasks).FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();

            return View(category);
        }
    }
}
