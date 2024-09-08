using Microsoft.AspNetCore.Mvc;
using TODOList.Models;
using TODOList.Data;
using System.Linq;

namespace TODOList.Controllers
{
    public class ObjetivoController : Controller
    {
        private readonly dbContext _context;

        public ObjetivoController(dbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var objetivos = _context.Objetivos.ToList();
            return View(objetivos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Objetivo objetivo)
        {
            if (ModelState.IsValid)
            {
                _context.Objetivos.Add(objetivo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objetivo);
        }

        public IActionResult Edit(int id)
        {
            var objetivo = _context.Objetivos.Find(id);
            if (objetivo == null)
            {
                return NotFound();
            }
            return View(objetivo);
        }

        [HttpPost]
        public IActionResult Edit(Objetivo objetivo)
        {
            if (ModelState.IsValid)
            {
                _context.Objetivos.Update(objetivo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objetivo);
        }

        public IActionResult Delete(int id)
        {
            var objetivo = _context.Objetivos.Find(id);
            if (objetivo == null)
            {
                return NotFound();
            }
            _context.Objetivos.Remove(objetivo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
