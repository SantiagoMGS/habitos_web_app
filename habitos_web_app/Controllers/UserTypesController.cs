using habitos_app.Web.Data;
using habitos_app.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace habitos_web_app.Controllers
{
    public class UserTypesController : Controller
    {
        private readonly DataContext _context;

        public UserTypesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserType.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserTypeDto dto)
        {

            if (ModelState.IsValid)
            {
                UserType userType = new UserType
                {
                    Description = dto.Description,
                };

                await _context.UserType.AddAsync(userType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }
    }
}
