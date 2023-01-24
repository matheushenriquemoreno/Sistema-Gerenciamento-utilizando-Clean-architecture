using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMVC.WebUI.Controllers
{
    public class ProdutoController : Controller
    {
       private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _produtoService.GetProdutos();

            return View(result);
        }

    }
}
