using CleanArchMVC.Application.DTOS;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMVC.WebUI.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;

        public ProdutoController(IProdutoService produtoService, ICategoriaService categoriaService)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _produtoService.GetProdutos();

            return View(result);
        }

        [HttpGet]
        public IActionResult VisualizarProduto(int id)
        {

            var result = _produtoService.GetProdutoByID(id).Result;

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            ViewBag.CategoriasTela = new SelectList(await _categoriaService.GetCategorias(), "Id", "Nome");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(ProdutoDTO produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.Add(produto);
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var produto = await _produtoService.GetProdutoByID(id);

            if (produto == null) { return NotFound(); }

            ViewBag.CategoriasTela = new SelectList(await _categoriaService.GetCategorias(), "Id", "Nome", produto.Categoria.Id);

            return View("Cadastrar", produto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ProdutoDTO produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.Update(produto);
                return RedirectToAction(nameof(Index));
            }

            return View("Cadastrar", produto);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> ExcluirProduto(int id)
        {
            await _produtoService.Remove(id);
            return Ok();
        }
    }
}
