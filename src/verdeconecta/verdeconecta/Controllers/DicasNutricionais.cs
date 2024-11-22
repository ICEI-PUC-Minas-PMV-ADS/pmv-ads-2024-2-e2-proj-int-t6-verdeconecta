using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using verdeconecta.Models;

namespace verdeconecta.Controllers
{
        public class DicasNutricionaisController : Controller
    {
        private readonly AppDbContext _context;

        public DicasNutricionaisController(AppDbContext context)
        {
            _context = context;
        }

        // Método para aumentar o contador de likes
        [HttpPost]
        public async Task<IActionResult> Like(int id)
        {
            var dica = await _context.DicasNutricionais.FindAsync(id);
            if (dica == null) return NotFound();

            dica.Likes++;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Método para aumentar o contador de dislikes
        [HttpPost]
        public async Task<IActionResult> Dislike(int id)
        {
            var dica = await _context.DicasNutricionais.FindAsync(id);
            if (dica == null) return NotFound();

            dica.Dislikes++;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: DicasNutricionais
        public async Task<IActionResult> Index()
        {
            return View(model: await _context.DicasNutricionais.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.DicasNutricionais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Dica,DataDica")] DicasNutricionais DicaNutricional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(DicaNutricional);  // Use a instância recebida, DicaNutricional, e não o nome da classe DicasNutricionais
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(DicaNutricional); // Retorne DicaNutricional para manter os dados em caso de erro
        }



    }
}
