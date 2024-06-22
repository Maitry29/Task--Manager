using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task_Manager.Data;
using Task_Manager.Models;
using Task = Task_Manager.Models.Task;
using System.Collections.Generic;



namespace Task_Manager.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        
      
        public IActionResult Index()
        {
            List<Task> objTaskList = _db.Tasks.ToList();
            return View(objTaskList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Task obj)
        {
            if (obj.Title == obj.Id.ToString())
            {
                ModelState.AddModelError("Title", "The Display Order cant not match the Title.");
            }

            if (obj.Title != null && obj.Title.ToLower() == "Test") //modelonly
            {
                ModelState.AddModelError("", "Test is an invalid value.");
            }
            if (ModelState.IsValid)
            {
                _db.Tasks.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Task Created Successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
           Task? TaskFromDb = _db.Tasks.Find(id);
            //  Task? TaskFromDb1 = _db.Categories.FirstOrDefault(u=>u.ID == id);
            //  Task? TaskFromDb2= _db.Categories.Where(u => u.ID == id).FirstOrDefault();

            if (TaskFromDb == null)
            {
                return NotFound();
            }
            return View(TaskFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Task obj)
        {

            if (ModelState.IsValid)
            {
                _db.Tasks.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Task Updated Successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Task? TaskFromDb = _db.Tasks.Find(id);
            // Task? TaskFromDb1 = _db.Categories.FirstOrDefault(u => u.ID == id);
            // Task? TaskFromDb2 = _db.Categories.Where(u => u.ID == id).FirstOrDefault();

            if (TaskFromDb == null)
            {
                return NotFound();
            }
            return View(TaskFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {Task? obj = _db.Tasks.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Tasks.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Task Deteted Successfully!";
            return RedirectToAction("Index");

        }



    }
}