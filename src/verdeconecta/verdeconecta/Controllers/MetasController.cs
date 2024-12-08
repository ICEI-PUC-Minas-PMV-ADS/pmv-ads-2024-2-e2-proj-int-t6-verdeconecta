using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using verdeconecta.Models;

namespace verdeconecta.Controllers
{
    [Authorize]
    public class MetasController : Controller
    {
        private readonly AppDbContext _context;

        public MetasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Metas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Metas.Include(m => m.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Metas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meta = await _context.Metas
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.IDMe == id);
            if (meta == null)
            {
                return NotFound();
            }

            return View(meta);
        }

        // GET: Metas/Create
        public IActionResult Create()
        {
            ViewData["idUsuario"] = new SelectList(_context.Usuarios, "Id", "Nome");
            return View();
        }

        // POST: Metas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDMe,DaraCriacao,duracaoDaMeta,metaCalorica,MetaFibras,metaProteinas,metaCarboidratos,metaSodio,metaGorduraTotais,idUsuario")] Meta meta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idUsuario"] = new SelectList(_context.Usuarios, "Id", "Nome", meta.idUsuario);
            return View(meta);
        }

        // GET: Metas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meta = await _context.Metas.FindAsync(id);
            if (meta == null)
            {
                return NotFound();
            }
            ViewData["idUsuario"] = new SelectList(_context.Usuarios, "Id", "Nome", meta.idUsuario);
            return View(meta);
        }

        // POST: Metas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDMe,DaraCriacao,duracaoDaMeta,metaCalorica,MetaFibras,metaProteinas,metaCarboidratos,metaSodio,metaGorduraTotais,idUsuario")] Meta meta)
        {
            if (id != meta.IDMe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetaExists(meta.IDMe))
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
            ViewData["idUsuario"] = new SelectList(_context.Usuarios, "Id", "Nome", meta.idUsuario);
            return View(meta);
        }

        // GET: Metas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meta = await _context.Metas
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.IDMe == id);
            if (meta == null)
            {
                return NotFound();
            }

            return View(meta);
        }

        // POST: Metas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meta = await _context.Metas.FindAsync(id);
            if (meta != null)
            {
                _context.Metas.Remove(meta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetaExists(int id)
        {
            return _context.Metas.Any(e => e.IDMe == id);
        }
    }
}
