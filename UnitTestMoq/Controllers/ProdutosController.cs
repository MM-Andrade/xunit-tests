using Microsoft.AspNetCore.Mvc;
using UnitTestMoq.Model;
using UnitTestMoq.Services;

namespace UnitTestMoq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _produtoService.ListarProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produtos = _produtoService.SelecionarProdutoPorID(id);
            return Ok(produtos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            var resultado = _produtoService.InserirProduto(produto);
            return Ok(resultado);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Produto produto)
        {
            var resultado = _produtoService.AtualizarProduto(produto);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var resultado = _produtoService.DeletarProduto(id);
            return Ok(resultado);
        }
    }
}
