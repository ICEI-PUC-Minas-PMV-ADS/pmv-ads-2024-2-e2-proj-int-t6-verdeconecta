using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using verdeconecta.Models;

namespace verdeconecta.Controllers
{
    [Authorize(Roles = "Cliente")]
    public class RefeicoesController : Controller
    {
        private readonly AppDbContext _context;

        public RefeicoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Refeicoes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Refeicoes.Include(r => r.Alimento).Include(r => r.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Refeicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refeicao = await _context.Refeicoes
                .Include(r => r.Alimento)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refeicao == null)
            {
                return NotFound();
            }

            return View(refeicao);
        }

        // GET: Refeicoes/Create
        public IActionResult Create()
        {
            ViewData["AlimentoId"] = new SelectList(_context.Alimentos, "Id", "Nome");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            return View();
        }

        // POST: Refeicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoRefeicao,DataDaRefeicao,AlimentoId,UsuarioId")] Refeicao refeicao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refeicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlimentoId"] = new SelectList(_context.Alimentos, "Id", "Nome", refeicao.AlimentoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", refeicao.UsuarioId);
            return View(refeicao);
        }

        // GET: Refeicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refeicao = await _context.Refeicoes.FindAsync(id);
            if (refeicao == null)
            {
                return NotFound();
            }
            ViewData["AlimentoId"] = new SelectList(_context.Alimentos, "Id", "Nome", refeicao.AlimentoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", refeicao.UsuarioId);
            return View(refeicao);
        }

        // POST: Refeicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoRefeicao,DataDaRefeicao,AlimentoId,UsuarioId")] Refeicao refeicao)
        {
            if (id != refeicao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refeicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefeicaoExists(refeicao.Id))
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
            ViewData["AlimentoId"] = new SelectList(_context.Alimentos, "Id", "Nome", refeicao.AlimentoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", refeicao.UsuarioId);
            return View(refeicao);
        }

        // GET: Refeicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refeicao = await _context.Refeicoes
                .Include(r => r.Alimento)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refeicao == null)
            {
                return NotFound();
            }

            return View(refeicao);
        }

        // POST: Refeicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refeicao = await _context.Refeicoes.FindAsync(id);
            if (refeicao != null)
            {
                _context.Refeicoes.Remove(refeicao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefeicaoExists(int id)
        {
            return _context.Refeicoes.Any(e => e.Id == id);
        }
        public async Task<IActionResult> RelatorioRefeicao()
        {
            if (User.Identity.IsAuthenticated)
            {
                string NameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);
                int idUsuario = Int32.Parse(NameIdentifier);

                var refeicoes = await _context.Refeicoes
                    .Where(r => r.UsuarioId == idUsuario)
                    .Include(r => r.Alimento)
                    .OrderByDescending(r => r.DataDaRefeicao)
                    .ToListAsync();

                if (refeicoes == null)
                {
                    return NotFound();
                }

                ViewBag.Refeicao = refeicoes;

                return View(refeicoes);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
