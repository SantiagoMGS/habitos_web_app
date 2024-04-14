using habitos_app.Web.Data;
using habitos_app.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        private List<SelectListItem> GetHabitTypeSelectList()
        {
            return _context.HabitType.Select(ht => new SelectListItem{
                Value = ht.Id.ToString(),
                Text = ht.Description
            }).ToList();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Habit> habits = await _context.Habit.Include(h => h.HabitType).ToListAsync();
            return View(habits);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> habitTypeItems = GetHabitTypeSelectList();
            ViewBag.habitTypeItems = habitTypeItems;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HabitDto dto)
        {
            if (ModelState.IsValid)
            {
                Habit habit = new Habit
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    HabitTypeId = dto.HabitTypeId
                };

                await _context.Habit.AddAsync(habit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            List<SelectListItem> habitTypeItems = GetHabitTypeSelectList();

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {

            Habit habit = await _context.Habit.Include(u => u.HabitType).FirstOrDefaultAsync(ht => ht.Id == id);

            if (habit == null)
            {
                return NotFound();
            }

            List<SelectListItem> habitTypeItems = GetHabitTypeSelectList();

            ViewBag.habitTypeItems = habitTypeItems;

            HabitDto habitEditDto = new HabitDto
            {
                Name = habit.Name,
                Description = habit.Description,
                HabitTypeId = habit.HabitTypeId
            };

            return View(habitEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HabitDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            Habit habit = await _context.Habit.FirstOrDefaultAsync(h => h.Id == dto.Id);
            if (habit == null)
            {
                return NotFound();
            }

            habit.Name = dto.Name;
            habit.Description = dto.Description;
            habit.HabitTypeId = dto.HabitTypeId;

            _context.Update(habit);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(HabitDto dto)
        {
            Habit? habit = await _context.Habit.FirstOrDefaultAsync(h => h.Id == dto.Id);
            if (habit == null)
            {
                return NotFound();
            }

            _context.Habit.Remove(habit);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
