using CleanArchMVC.Domain.Account;
using CleanArchMVC.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMVC.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAutentificate _autenficacao;

        public LoginController(IAutentificate autenficacao)
        {
            _autenficacao = autenficacao;
        }


        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _autenficacao.Autentificar(model.Email, model.Senha);

            if (result)
            {
                if (string.IsNullOrEmpty(model.ReturnUrl))
                {

                    return RedirectToAction("Index", "Home");
                }
                return Redirect(model.ReturnUrl);
            }

            ModelState.AddModelError(string.Empty, "login invalido");
            return View(model);
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegisterViewModel model)
        {
            var result = await _autenficacao.RegistrarUser(model.Email, model.Senha);

            if (result)
            {
                return Redirect("/");
            }

            ModelState.AddModelError(String.Empty, "Houve um erro ao criar o usuario");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _autenficacao.Logout();
            return Redirect("/Login/Login");
        }

    }
}
