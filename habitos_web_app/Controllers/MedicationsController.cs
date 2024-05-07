using habitos_app.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using habitos_app.Web.Data;
using System.Xml.Linq;

namespace habitos_web_app.Controllers
{
    public class MedicationsController : Controller
    {
        private readonly DataContext _context;

        public MedicationsController(DataContext context)
        {
            _context = context;
        }

        private List<SelectListItem> GetViaAdminSelectList()
        {
            return _context.ViaAdmin.Select(va => new SelectListItem
            {
                Value = va.Id.ToString(),
                Text = va.Description
            }).ToList();
        }

        private List<SelectListItem> GetUnitSelectList()
        {
            return _context.Unit.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.Description
            }).ToList();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Medication> medications = await _context.Medication.Include(va => va.ViaAdmin).Include(u => u.Unit).ToListAsync();
            return View(medications);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Obtiene la lista de tipos de ViaAdmin
            List<SelectListItem> ViaAdmins = GetViaAdminSelectList();
            // Asigna la lista de tipos de ViaAdmin a la vista para mostrar en el formulario
            ViewBag.ViaAdmins = ViaAdmins;
            // Obtiene la lista de tipos de ViaAdmin
            List<SelectListItem> Units = GetUnitSelectList();
            // Asigna la lista de tipos de ViaAdmin a la vista para mostrar en el formulario
            ViewBag.Units = Units;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MedicationDto dto)
        {
            if (ModelState.IsValid)
            {
                Medication medication = new Medication { 
                    Name = dto.Name,
                    UnitId = dto.UnitId,
                    ViaAdminId = dto.ViaAdminId,
                    Quantity = dto.Quantity
                };
                await _context.Medication.AddAsync(medication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            // Obtiene el medicamento a editar y la lista de tipos de medicamento
            Medication medication = await _context.Medication.Include(va => va.ViaAdmin).Include(u => u.Unit).FirstOrDefaultAsync(u => u.Id == id);
            // Si el medicamento no existe, retorna un error 404 y no revienta la aplicación
            if (medication == null)
            {
                return NotFound();
            }

            List<SelectListItem> ViaAdmins = GetViaAdminSelectList();
            ViewBag.ViaAdmins = ViaAdmins;
            List<SelectListItem> Units = GetUnitSelectList();
            ViewBag.Units = Units;

            MedicationDto medicationEditDto = new MedicationDto
            {
                Name = medication.Name,
                ViaAdminId = medication.ViaAdminId,
                UnitId = medication.UnitId,
                Quantity = medication.Quantity
            };

            return View(medicationEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MedicationDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            Medication medication = await _context.Medication.Include(va => va.ViaAdmin).Include(u => u.Unit).FirstOrDefaultAsync(u => u.Id == dto.Id);
            if (medication == null)
            {
                return NotFound();
            }

            medication.Name = medication.Name;
            medication.ViaAdminId = medication.ViaAdminId;
            medication.UnitId = medication.UnitId;
            medication.Quantity = medication.Quantity;

            _context.Update(medication);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(MedicationDto dto)
        {
            Medication medication = await _context.Medication.FirstOrDefaultAsync(u => u.Id == dto.Id);
            if (medication == null)
            {
                return NotFound();
            }

            _context.Medication.Remove(medication);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}