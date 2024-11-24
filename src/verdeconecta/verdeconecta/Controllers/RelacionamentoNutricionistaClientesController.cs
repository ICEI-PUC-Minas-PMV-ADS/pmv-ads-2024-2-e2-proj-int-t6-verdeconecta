using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using verdeconecta.Models;

namespace verdeconecta.Controllers
{
    public class RelacionamentoNutricionistaClientesController : Controller
    {
        private readonly AppDbContext _context;

        public RelacionamentoNutricionistaClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RelacionamentoNutricionistaClientes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.RelacionamentoNutricionistaCliente.Include(r => r.Cliente).Include(r => r.Nutricionista);
            return View(await appDbContext.ToListAsync());
        }

        // GET: RelacionamentoNutricionistaClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relacionamentoNutricionistaCliente = await _context.RelacionamentoNutricionistaCliente
                .Include(r => r.Cliente)
                .Include(r => r.Nutricionista)
                .FirstOrDefaultAsync(m => m.IdNutricionista == id);
            if (relacionamentoNutricionistaCliente == null)
            {
                return NotFound();
            }

            return View(relacionamentoNutricionistaCliente);
        }

        // GET: RelacionamentoNutricionistaClientes/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Usuarios, "Id", "Email");
            ViewData["IdNutricionista"] = new SelectList(_context.Usuarios, "Id", "Email");
            return View();
        }

        // POST: RelacionamentoNutricionistaClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNutricionista,IdCliente")] RelacionamentoNutricionistaCliente relacionamentoNutricionistaCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relacionamentoNutricionistaCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Usuarios, "Id", "Email", relacionamentoNutricionistaCliente.IdCliente);
            ViewData["IdNutricionista"] = new SelectList(_context.Usuarios, "Id", "Email", relacionamentoNutricionistaCliente.IdNutricionista);
            return View(relacionamentoNutricionistaCliente);
        }

        // GET: RelacionamentoNutricionistaClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relacionamentoNutricionistaCliente = await _context.RelacionamentoNutricionistaCliente.FindAsync(id);
            if (relacionamentoNutricionistaCliente == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Usuarios, "Id", "Email", relacionamentoNutricionistaCliente.IdCliente);
            ViewData["IdNutricionista"] = new SelectList(_context.Usuarios, "Id", "Email", relacionamentoNutricionistaCliente.IdNutricionista);
            return View(relacionamentoNutricionistaCliente);
        }

        // POST: RelacionamentoNutricionistaClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNutricionista,IdCliente")] RelacionamentoNutricionistaCliente relacionamentoNutricionistaCliente)
        {
            if (id != relacionamentoNutricionistaCliente.IdNutricionista)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relacionamentoNutricionistaCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelacionamentoNutricionistaClienteExists(relacionamentoNutricionistaCliente.IdNutricionista))
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
            ViewData["IdCliente"] = new SelectList(_context.Usuarios, "Id", "Email", relacionamentoNutricionistaCliente.IdCliente);
            ViewData["IdNutricionista"] = new SelectList(_context.Usuarios, "Id", "Email", relacionamentoNutricionistaCliente.IdNutricionista);
            return View(relacionamentoNutricionistaCliente);
        }

        // GET: RelacionamentoNutricionistaClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relacionamentoNutricionistaCliente = await _context.RelacionamentoNutricionistaCliente
                .Include(r => r.Cliente)
                .Include(r => r.Nutricionista)
                .FirstOrDefaultAsync(m => m.IdNutricionista == id);
            if (relacionamentoNutricionistaCliente == null)
            {
                return NotFound();
            }

            return View(relacionamentoNutricionistaCliente);
        }

        // POST: RelacionamentoNutricionistaClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relacionamentoNutricionistaCliente = await _context.RelacionamentoNutricionistaCliente.FindAsync(id);
            if (relacionamentoNutricionistaCliente != null)
            {
                _context.RelacionamentoNutricionistaCliente.Remove(relacionamentoNutricionistaCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelacionamentoNutricionistaClienteExists(int id)
        {
            return _context.RelacionamentoNutricionistaCliente.Any(e => e.IdNutricionista == id);
        }
    }
}
