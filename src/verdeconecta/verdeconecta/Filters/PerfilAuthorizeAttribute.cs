using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace verdeconecta.Filters
{
    public class PerfilAuthorizeAttribute : ActionFilterAttribute
    {
        private readonly string _perfilPermitido;

        public PerfilAuthorizeAttribute(string perfilPermitido)
        {
            _perfilPermitido = perfilPermitido;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User;

            if (user.Identity.IsAuthenticated)
            {
                var perfil = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

                if (perfil == null || perfil != _perfilPermitido)
                {
                    // Redirecionar para uma página de acesso negado
                    context.Result = new RedirectToActionResult("AccessDenied", "Usuarios", null);
                }
            }
            else
            {
                // Redirecionar para a página de login se não estiver autenticado
                context.Result = new RedirectToActionResult("Login", "Usuarios", null);
            }
        }
    }
}
