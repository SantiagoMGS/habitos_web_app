using habitos_app.Web.Data;
using habitos_app.Web.Models;
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
    }
}
