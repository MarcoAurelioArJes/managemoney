using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManageMoney.Controllers
{
    public class InicioController : Controller
    {
        [AllowAnonymous]
        public IActionResult Inicio()
        {
            return View();
        }

        [AllowAnonymous]

        public IActionResult Cadastro()
        {
            return View();
        }

        [AllowAnonymous]

        public IActionResult Login()
        {
            return View();
        }
    }
}
