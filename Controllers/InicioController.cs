using Microsoft.AspNetCore.Mvc;

namespace ManageMoney.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Inicio()
        {
            return View();
        }


        public IActionResult Cadastro()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }
    }
}
