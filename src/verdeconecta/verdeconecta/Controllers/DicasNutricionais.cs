using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using verdeconecta.Models;
using verdeconecta.Filters;

namespace verdeconecta.Controllers
{
    [Authorize]
    [PerfilAuthorize("Nutricionista")] // Restringe acesso ao perfil Nutricionista
    public class DicasNutricionaisController : Controller
    {
        private readonly AppDbContext _context;

        public DicasNutricionaisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DicasNutricionais
        public async Task<IActionResult> Index()
        {
            return View(model: await _context.DicasNutricionais.ToListAsync());
        }

        // GET: DicasNutricionais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dicaNutricional = await _context.DicasNutricionais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dicaNutricional == null)
            {
                return NotFound();
            }

            return View(dicaNutricional);
        }

        // GET: DicasNutricionais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DicasNutricionais/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Dica,DataDica")] DicasNutricionais dicaNutricional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dicaNutricional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dicaNutricional);
        }

        // GET: DicasNutricionais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dicaNutricional = await _context.DicasNutricionais.FindAsync(id);
            if (dicaNutricional == null)
            {
                return NotFound();
            }
            return View(dicaNutricional);
        }

        // POST: DicasNutricionais/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Dica,DataDica")] DicasNutricionais dicaNutricional)
        {
            if (id != dicaNutricional.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dicaNutricional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DicaNutricionalExists(dicaNutricional.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dicaNutricional);
        }

        // GET: DicasNutricionais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dicaNutricional = await _context.DicasNutricionais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dicaNutricional == null)
            {
                return NotFound();
            }

            return View(dicaNutricional);
        }

        // POST: DicasNutricionais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dicaNutricional = await _context.DicasNutricionais.FindAsync(id);
            if (dicaNutricional != null)
            {
                _context.DicasNutricionais.Remove(dicaNutricional);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DicaNutricionalExists(int id)
        {
            return _context.DicasNutricionais.Any(e => e.Id == id);
        }
    }
}
