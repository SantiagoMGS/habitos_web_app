using habitos_app.Web.Data;
using habitos_app.Web.Models;
using habitos_web_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace habitos_web_app.Controllers
{
    public class HabitTypesController : Controller
    {
        private readonly DataContext _context;

        public HabitTypesController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.HabitType.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HabitTypeDto dto)
        {

            if (ModelState.IsValid)
            {
                HabitType habitType = new HabitType
                {
                    Description = dto.Description,
                };

                await _context.HabitType.AddAsync(habitType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }
    }
}
