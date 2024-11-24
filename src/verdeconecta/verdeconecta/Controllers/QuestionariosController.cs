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
    public class QuestionariosController : Controller
    {
        private readonly AppDbContext _context;

        public QuestionariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Questionarios
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Questionarios.Include(q => q.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Questionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionario = await _context.Questionarios
                .Include(q => q.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionario == null)
            {
                return NotFound();
            }

            return View(questionario);
        }

        // GET: Questionarios/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            return View();
        }

        // POST: Questionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoDieta,TemRestricaoAlimentar,RestricaoDetalhes,NivelAtividadeFisica,ObjetivoPrincipal,RefeicoesPorDia,HorarioRefeicoes,ConsumoFrutasVegetais,UsuarioId")] Questionario questionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", questionario.UsuarioId);
            return View(questionario);
        }

        // GET: Questionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionario = await _context.Questionarios.FindAsync(id);
            if (questionario == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", questionario.UsuarioId);
            return View(questionario);
        }

        // POST: Questionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoDieta,TemRestricaoAlimentar,RestricaoDetalhes,NivelAtividadeFisica,ObjetivoPrincipal,RefeicoesPorDia,HorarioRefeicoes,ConsumoFrutasVegetais,UsuarioId")] Questionario questionario)
        {
            if (id != questionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionarioExists(questionario.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", questionario.UsuarioId);
            return View(questionario);
        }

        // GET: Questionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionario = await _context.Questionarios
                .Include(q => q.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionario == null)
            {
                return NotFound();
            }

            return View(questionario);
        }

        // POST: Questionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionario = await _context.Questionarios.FindAsync(id);
            if (questionario != null)
            {
                _context.Questionarios.Remove(questionario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionarioExists(int id)
        {
            return _context.Questionarios.Any(e => e.Id == id);
        }
    }
}
