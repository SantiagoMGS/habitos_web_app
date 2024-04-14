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
    }
}
