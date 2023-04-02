using AutoMapper;
using CleanArchMVC.Application.CQRSProduto.Commands;
using CleanArchMVC.Application.DTOS;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Interfaces.Fila;
using CleanArchMVC.Application.Produtos.Commands;
using CleanArchMVC.Application.Produtos.Queries;
using MediatR;


namespace CleanArchMVC.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ICategoriaService _categoriaService;

        public ProdutoService(IMapper mapper, IMediator mediator, ICategoriaService categoriaService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _categoriaService = categoriaService;
        }

        public async Task Add(ProdutoDTO produtoDTO)
        {
            var produtoCommand = _mapper.Map<ProdutoCreateCommand>(produtoDTO);

            var produtoAdicionado = await _mediator.Send(produtoCommand);

            //await _mediator.Publish(new NotificarCriarProdutoNotification(produtoAdicionado.ConverterJson()));
        }

        public async Task<ProdutoDTO> GetProdutoByID(int id)
        {
            var queryBuscarProdutoQuery = new GetProdutoByIdQuery(id);

            var produto = await _mediator.Send(queryBuscarProdutoQuery);

            return _mapper.Map<ProdutoDTO>(produto);
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            var produtosQuery = new GetProdutosQuery();

            var produtos = await _mediator.Send(produtosQuery);

            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public async Task Remove(int id)
        {
            var produtoCommand = new ProdutoRemoveCommand(id);

            await _mediator.Send(produtoCommand);
        }

        public async Task Update(ProdutoDTO produtoDTO)
        {
            var updateCommand = _mapper.Map<ProdutoUpdateCommand>(produtoDTO);

            await _mediator.Send(updateCommand);
        }
    }
}
