using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly Context _context;
        public TaskController(Context context)
        {
            _context = context;
        }

        public IActionResult Index(string getTask)
        {
            if (getTask != null)
            {
                Todo task = new Todo
                {
                    Desc = getTask
                };

                _context.Add(task);
                _context.SaveChanges();
            }

            var tasks = _context.Todos.ToList();

            return View(tasks);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var delete = _context.Todos.Find(id);

                _context.Remove(delete);
                _context.SaveChanges();
            }

            else
            {
                var todo = _context.Todos.ToList();

                foreach (var item in todo)
                {
                    _context.Remove(item);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
