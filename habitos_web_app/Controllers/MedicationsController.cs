using habitos_app.Web.Data;
using habitos_app.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace habitos_web_app.Controllers
{
    public class MedicationsController : Controller
    {
        private readonly DataContext _context;

        public MedicationsController(DataContext context)
        {
            _context = context;
        }

        private List<SelectListItem> GetUnitSelectList()
        {
            return _context.Unit.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.Description
            }).ToList();
        }

        private List<SelectListItem> GetViaAdminSelectList()
        {
            return _context.ViaAdmin.Select(va => new SelectListItem
            {
                Value = va.Id.ToString(),
                Text = va.Description
            }).ToList();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Medication> medications = await _context.Medication.Include(m => m.Unit).Include(m => m.ViaAdmin).ToListAsync();
            return View(medications);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> Units = GetUnitSelectList();
            ViewBag.Units = Units;
            List<SelectListItem> ViaAdmins = GetViaAdminSelectList();
            ViewBag.ViaAdmins = ViaAdmins;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MedicationDto dto)
        {
            if (ModelState.IsValid)
            {
                Medication medication = new Medication
                {
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

            Medication medication = await _context.Medication.Include(m => m.Unit).Include(m => m.ViaAdmin).FirstOrDefaultAsync(m => m.Id == id);

            if (medication == null)
            {
                return NotFound();
            }
            List<SelectListItem> Units = GetUnitSelectList();
            ViewBag.Units = Units;
            List<SelectListItem> ViaAdmins = GetViaAdminSelectList();
            ViewBag.ViaAdmins = ViaAdmins;

            MedicationDto medicationEditDto = new MedicationDto
            {
                Name = medication.Name,
                UnitId = medication.UnitId,
                ViaAdminId = medication.ViaAdminId,
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

            Medication medication = await _context.Medication.FirstOrDefaultAsync(m => m.Id == dto.Id);
            if (medication == null)
            {
                return NotFound();
            }

            medication.Name = dto.Name;
            medication.UnitId = dto.UnitId;
            medication.ViaAdminId = dto.ViaAdminId;
            medication.Quantity = dto.Quantity;

            _context.Update(medication);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MedicationDto dto)
        {
            Medication? medication = await _context.Medication.FirstOrDefaultAsync(m => m.Id == dto.Id);
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
