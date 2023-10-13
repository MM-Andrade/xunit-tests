using UnitTestMoq.Data;
using UnitTestMoq.Model;

namespace UnitTestMoq.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProdutoService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Produto AtualizarProduto(Produto produto)
        {
            var resultado = _applicationDbContext.Produtos.Update(produto);
            _applicationDbContext.SaveChanges();

            return resultado.Entity;

        }

        public bool DeletarProduto(int id)
        {
            var produto = SelecionarProdutoPorID(id);
            
            if (produto == null)
                return false;

            var resultado = _applicationDbContext.Produtos.Remove(produto);
            _applicationDbContext.SaveChanges();

            return resultado != null ? true : false;
        }

        public Produto InserirProduto(Produto produto)
        {
            var resultado = _applicationDbContext.Produtos.Add(produto);
            _applicationDbContext.SaveChanges();
            return resultado.Entity;
        }

        public IEnumerable<Produto> ListarProdutos() => _applicationDbContext.Produtos.ToList();

        public Produto SelecionarProdutoPorID(int id) => _applicationDbContext.Produtos.FirstOrDefault(p => p.Id == id);
    }
}
