using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ToDoListWebApp.Data;
using ToDoListWebApp.Models;

namespace ToDoListWebApp.Controllers
{
    public class NotesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Notes.ToList());
        }

        [HttpGet]
        public IActionResult ShowAll()
        {
            return View(_context.Notes.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Record")] Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ClearDb()
        {
            foreach (var note in _context.Notes)
                _context.Remove(note);
            _context.SaveChanges();
            return RedirectToAction("Index", "Notes");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var note = _context.Notes.Single(x => x.Id == id);
            return View(note);
        }

        [HttpPost]
        public IActionResult Edit(Note note)
        {
            _context.Update(note);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var note = _context.Notes.Single(x => x.Id == id);
            _context.Remove(note);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Details(int id)
        {
            var note = _context.Notes.Single(x => x.Id == id);
            return View(note);
        }
    }
}