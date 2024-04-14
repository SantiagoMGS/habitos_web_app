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

        // Método para obtener los SelectListItem de UserType
        private List<SelectListItem> GetUserTypeSelectList()
        {
            return _context.UserType.Select(ut => new SelectListItem
            {
                Value = ut.Id.ToString(),
                Text = ut.Description
            }).ToList();
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
            // Obtiene la lista de tipos de usuario
            List<SelectListItem> userTypeItems = GetUserTypeSelectList();
            // Asigna la lista de tipos de usuario a la vista para mostrar en el formulario
            ViewBag.UserTypeItems = userTypeItems;
            return View();
        }

        // Método para procesar el formulario de creación de usuarios (Vista Create)
        // Valida los datos ingresados y crea un nuevo usuario, si tiene un error recarga la vista con los datos ingresados
        [HttpPost]
        public async Task<IActionResult> Create(UserDto dto)
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
            List<SelectListItem> userTypeItems = GetUserTypeSelectList();

            return View(dto); 
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            // Obtiene el usuario a editar y la lista de tipos de usuario
            User user = await _context.User.Include(u => u.UserType).FirstOrDefaultAsync(u => u.Id == id);
            // Si el usuario no existe, retorna un error 404 y no revienta la aplicación
            if (user == null)
            {
                return NotFound();
            }

            List<SelectListItem> userTypeItems = GetUserTypeSelectList();

            ViewBag.UserTypeItems = userTypeItems;

            UserDto userEditDto = new UserDto
            {
                Name = user.Name,
                Email = user.Email,
                UserTypeId = user.UserTypeId
            };

            return View(userEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            User user = await _context.User.FirstOrDefaultAsync(u => u.Id == dto.Id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = dto.Name;
            user.Email = dto.Email;
            user.UserTypeId = dto.UserTypeId;

            _context.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.User.Include(u => u.UserType).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost] 
        public async Task<IActionResult> Delete(UserDto dto)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == dto.Id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }




    }
}
