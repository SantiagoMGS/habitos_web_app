using habitos_app.Web.Data;
using habitos_app.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace habitos_web_app.Controllers
{
    public class HabitsController : Controller
    {
        private readonly DataContext _context;

        public HabitsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Habit> users = await _context.Habit.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
