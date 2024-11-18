using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using verdeconecta.Models;

namespace verdeconecta.Controllers
{
    public class UsuariosController : Controller
    {
    private readonly AppDbContext _context;
    private readonly string _remetente;
    private readonly string _emailRemetente;
    private readonly string _senhaEmail;
    private readonly string _servidorSmtp;
    private readonly int _portaSmtp;
    

        public UsuariosController(AppDbContext context)
        {
            _context = context;

            _remetente = "Suporte Verde Conecta";
            _emailRemetente = "verdeconecta@hotmail.com";
            _senhaEmail = "xxxxxxxxx";
            _servidorSmtp = "smtp-mail.outlook.com";
            _portaSmtp = 587;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        public IActionResult Login() 
        {
            return View();
        }


        private async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            using (var client = new SmtpClient(_servidorSmtp, _portaSmtp))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_emailRemetente, _senhaEmail);
                client.EnableSsl = true;

                var message = new MailMessage
                {
                    From = new MailAddress(_emailRemetente, _remetente),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                message.To.Add(toEmail);
                await client.SendMailAsync(message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            var dados = await _context.Usuarios
              
               .FirstOrDefaultAsync(u => u.Email == usuario.Email);

            if (dados == null)
            {
                ViewBag.Message = "E-mail e/ou senha invalido!";
                return View();
            }

            bool senhaok = BCrypt.Net.BCrypt.Verify(usuario.Senha, dados.Senha);

            if (senhaok)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, dados.Nome),
                    new Claim(ClaimTypes.NameIdentifier, dados.Id.ToString()),
                    new Claim(ClaimTypes.Role, dados.Perfil.ToString()),
                };

                var usuarioIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(principal, props);

                return Redirect("/");
            }
            else
            {
                ViewBag.Message = "E-mail e/ou senha invalido!";
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        { 
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Usuarios");
        }


        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
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
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,DataDeNascimento,Peso,Altura,Senha,Perfil")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,DataDeNascimento,Peso,Altura,Senha,Perfil")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }


        [HttpGet]
        
        public IActionResult EsqueciSenha()
        {
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> EsqueciSenha(string email)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
            if (usuario == null)
            {
                ViewBag.Message = "E-mail não encontrado.";
                return View();
            }

         
            usuario.TokenRedefinicaoSenha = Guid.NewGuid().ToString();
            usuario.TokenValidade = DateTime.UtcNow.AddHours(1);

         
            _context.Update(usuario);
            await _context.SaveChangesAsync();

          
            string callbackUrl = Url.Action("RedefinirSenha", "Usuarios", new { token = usuario.TokenRedefinicaoSenha }, Request.Scheme);
            string emailBody = $@"
              <h3>Redefinição de Senha</h3>
              <p>Clique no link abaixo para redefinir sua senha:</p>
              <a href='{callbackUrl}'>Redefinir Senha</a>";

            await SendEmailAsync(usuario.Email, "Redefinição de Senha", emailBody);

          
            ViewBag.Message = "Um link para redefinir sua senha foi enviado para o seu e-mail.";
            return View("ConfirmacaoEsqueciSenha");
        }


        [HttpGet]
        public IActionResult RedefinirSenha()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RedefinirSenha(string senhaAntiga, string novaSenha, string confirmarNovaSenha)
        {
           
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id.ToString() == usuarioId);

            if (usuario == null)
            {
                ViewBag.Mensagem = "favor fazer login para redefinir a senha.";
                return View();
            }

           
            if (!BCrypt.Net.BCrypt.Verify(senhaAntiga, usuario.Senha))
            {
                ViewBag.Mensagem = "A senha antiga está incorreta.";
                return View();
            }

           
            if (novaSenha != confirmarNovaSenha)
            {
                ViewBag.Mensagem = "As novas senhas não coincidem.";
                return View();
            }

           
            if (novaSenha.Length < 8)
            {
                ViewBag.Mensagem = "A nova senha deve ter no mínimo 8 caracteres.";
                return View();
            }

           
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(novaSenha);

         
            _context.Update(usuario);
            await _context.SaveChangesAsync();

            
            ViewBag.Mensagem = "Senha redefinida com sucesso!";
            return View();
        }
    }
}



