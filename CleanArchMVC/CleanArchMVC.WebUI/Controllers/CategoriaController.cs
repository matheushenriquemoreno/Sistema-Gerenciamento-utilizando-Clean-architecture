using CleanArchMVC.Application.DTOS;
using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CleanArchMVC.WebUI.Controllers
{
    [Authorize]
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
            var user = Request.HttpContext.User;

            var result = await _categoriaService.GetCategorias();

            return View(result);
        }


        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Cadastrar(CategoriaDTO categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.Add(categoria);
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var categoria = await _categoriaService.GetByIDCategoria(id);

            if (categoria == null) { return NotFound(); }

            return View("Cadastrar", categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(CategoriaDTO categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.Update(categoria);
                return RedirectToAction(nameof(Index));
            }

            return View("Cadastrar", categoria);
        }


        //[HttpGet]
        //public async Task<IActionResult> Deletar()
        //{

        //}
    }
}
