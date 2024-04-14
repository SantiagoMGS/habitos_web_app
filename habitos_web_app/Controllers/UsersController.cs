using habitos_app.Web.Data;
using habitos_app.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace habitos_web_app.Controllers
{
    public class UsersController : Controller
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        // Método para mostrar la lista de usuarios (Vista Index)
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Incluye el UserType al recuperar los usuarios
            IEnumerable<User> users = await _context.User.Include(ut => ut.UserType).ToListAsync();
            return View(users);
        }

        // Método para mostrar el formulario de creación de usuarios (Vista Create)
        // Obtiene la lista de tipos de usuario para mostrar en el formulario
        [HttpGet]
        public IActionResult Create()
        {
            var userTypeItems = _context.UserType.Select(ut => new SelectListItem
            {
                Value = ut.Id.ToString(),
                Text = ut.Description
            }).ToList();

            ViewBag.UserTypeItems = userTypeItems;
            return View();
        }

        // Método para procesar el formulario de creación de usuarios (Vista Create)
        // Valida los datos ingresados y crea un nuevo usuario, si tiene un error recarga la vista con los datos ingresados
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto dto)
        {
            // Validar los datos ingresados en base al modelo
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    UserTypeId = dto.UserTypeId
                };

                await _context.User.AddAsync(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Recargar la lista en caso de error
            var userTypeItems = _context.UserType.Select(userType => new SelectListItem
            {
                Value = userType.Id.ToString(),
                Text = userType.Description
            }).ToList();
            ViewBag.UserTypeItems = userTypeItems;

            return View(dto); 
        }

    }
}
