using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using verdeconecta.Models;

namespace verdeconecta.Controllers
{
    [Authorize]

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
                .Include(r => r.Comentarios)  // Inclui os comentários
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
        public async Task<IActionResult> Create([Bind("Id,TipoRefeicao,DataDaRefeicao,Quantidade,AlimentoId,UsuarioId")] Refeicao refeicao)
        {
            if (ModelState.IsValid)
            {
                var alimento = await _context.Alimentos.FindAsync(refeicao.AlimentoId);
                if (alimento == null)
                {
                    ModelState.AddModelError("", "Alimento não encontrado!");
                    ViewData["AlimentoId"] = new SelectList(_context.Alimentos, "Id", "Nome", refeicao.AlimentoId);
                    ViewData["UsuarioId"] = new SelectList(_context.Alimentos, "Id", "Email", refeicao.UsuarioId);
                    return View(refeicao);
                }
                double fator = refeicao.Quantidade / 100;
                refeicao.Calorias = (double)(alimento.Calorias * fator);
                refeicao.Proteinas = (double)(alimento.Proteinas * fator);
                refeicao.Fibras = (double)(alimento.Fibras * fator);
                refeicao.Carboidratos = (double)(alimento.Carboidratos * fator);
                refeicao.Gorduras = (double)(alimento.Gorduras * fator);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoRefeicao,DataDaRefeicao,Quantidade,AlimentoId,UsuarioId")] Refeicao refeicao)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarComentario(int refeicaoId, string NutricionistaComment)
        {
            if (User.Identity.IsAuthenticated)
            {
                // Verificar se o comentário está vazio ou é nulo
                if (string.IsNullOrWhiteSpace(NutricionistaComment))
                {
                    // Retornar uma mensagem de erro ou definir um comentário padrão
                    return BadRequest("O comentário não pode ser vazio.");
                }

                // Identifica o usuário logado
                string nameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);
                int idNutricionista = Int32.Parse(nameIdentifier);

                // Busca a refeição correspondente
                var refeicao = await _context.Refeicoes.FindAsync(refeicaoId);
                if (refeicao == null)
                {
                    return NotFound();
                }

                // Busca o nutricionista logado para pegar o nome
                var nutricionista = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == idNutricionista);

                // Cria o comentário
                var consulta = new Comentario
                {
                    NutricionistaId = idNutricionista,
                    NutricionistaName = nutricionista.Nome, // Armazena o nome do nutricionista
                    RefeicaoId = refeicaoId,
                    NutricionistaComment = NutricionistaComment,
                    CreatedAt = DateTime.UtcNow
                };

                // Salva o comentário no banco de dados
                _context.Comentarios.Add(consulta);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Details), new { id = refeicaoId });
            }

            return Unauthorized();
        }

    }
}