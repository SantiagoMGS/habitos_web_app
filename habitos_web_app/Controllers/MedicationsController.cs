using habitos_app.Web.Data;
using habitos_app.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace habitos_web_app.Controllers
{
    public class MedicationsController : Controller
    {
        private readonly DataContext _context;

        public MedicationsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Medication> medications = await _context.Medication.ToListAsync();
            return View(medications);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Medication medication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medication);
        }
    }
}
