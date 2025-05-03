using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoTracker.Data;
using TodoTracker.Models;
using TodoTracker.ViewModels;

namespace TodoTracker.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var tasks = _context.Tasks.Include(t => t.Categories).ToList();
            return View(tasks);
        }


        public ActionResult Create()
        {
            var vm = new TaskViewModel
            {
                AvailableCategories = _context.Categories.ToList()
            };
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var task = new TaskModel
                {
                    TaskTitle = vm.TaskTitle,
                    TaskDescription = vm.TaskDescription,
                    TaskAssignDate = vm.TaskAssignDate,
                    IsCompleted = vm.IsCompleted,
                    Categories = _context.Categories.Where(c => vm.SelectedCategoryIds!.Contains(c.Id)).ToList()
                };

                _context.Tasks.Add(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            vm.AvailableCategories = _context.Categories.ToList();
            return View(vm);
        }



        public ActionResult Edit(int id)
        {
            var task = _context.Tasks.Include(t => t.Categories).FirstOrDefault(t => t.Id == id);
            if (task == null || task.IsCompleted)
                return NotFound();

            var vm = new TaskViewModel
            {
                Id = task.Id,
                TaskTitle = task.TaskTitle,
                TaskDescription = task.TaskDescription,
                TaskAssignDate = task.TaskAssignDate,
                IsCompleted = task.IsCompleted,
                SelectedCategoryIds = task.Categories!.Select(c => c.Id).ToList(),
                AvailableCategories = _context.Categories.ToList()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaskViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var task = _context.Tasks.Include(t => t.Categories).FirstOrDefault(t => t.Id == vm.Id);
                if (task == null)
                    return NotFound();

                task.TaskTitle = vm.TaskTitle;
                task.TaskDescription = vm.TaskDescription;
                task.TaskAssignDate = vm.TaskAssignDate;
                task.IsCompleted = vm.IsCompleted;
                task.Categories!.Clear();

                foreach (var categoryId in vm.SelectedCategoryIds!)
                {
                    var category = _context.Categories.Find(categoryId);
                    if (category != null)
                        task.Categories.Add(category);
                }

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            vm.AvailableCategories = _context.Categories.ToList();
            return View(vm);
        }

        public ActionResult DeleteConfirmation(int id)
        {
            var task = _context.Tasks
                .Include(t => t.Categories)
                .FirstOrDefault(t => t.Id == id);

            if (task == null || task.IsCompleted)
                return NotFound();

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null || task.IsCompleted)
                return NotFound();

            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Complete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
                return NotFound();

            task.IsCompleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
