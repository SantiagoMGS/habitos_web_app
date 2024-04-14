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


        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            // Obtiene el usuario a editar y la lista de tipos de usuario
            UserType userType = await _context.UserType.FindAsync(id);
            // Si el usuario no existe, retorna un error 404 y no revienta la aplicación
            if (userType == null)
            {
                return NotFound();
            }

            UserTypeDto userTypeEditDto = new UserTypeDto
            {
                Description = userType.Description,
            };

            return View(userTypeEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserTypeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            UserType userType = await _context.UserType.FirstOrDefaultAsync(u => u.Id == dto.Id);
            if (userType == null)
            {
                return NotFound();
            }

            userType.Description = dto.Description;

            _context.Update(userType);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
