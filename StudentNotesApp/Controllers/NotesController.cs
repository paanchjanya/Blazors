using Microsoft.AspNetCore.Mvc;
using StudentNotesApp.Models;
namespace StudentNotesApp.Controllers;


public class NotesController : Controller
{
    private static List<Note> _notes = new();
    private static int _nextId = 1;


    // GET /Notes
    public IActionResult Index()
    {
        return View(_notes);
    }

    // GET /Notes/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST /Notes/Create
    [HttpPost]
    public IActionResult Create(Note note)
    {
        if (ModelState.IsValid)
        {
            note.Id = _nextId++;
            note.Created = DateTime.UtcNow;
            _notes.Add(note);
            return RedirectToAction("Index");
        }
        return View(note);
    }


    // POST /Notes/Delete/1
    public IActionResult Delete(int id)
    {
        var note = _notes.FirstOrDefault(n => n.Id == id);
        if(note == null) return NotFound();
        _notes.Remove(note);
        return RedirectToAction("Index");
    }
}