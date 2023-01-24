using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMVC.WebUI.Controllers
{
    public class CategoriaController : Controller
    {
       private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _categoriaService.GetCategorias();

            return View(result);
        }

    }
}
