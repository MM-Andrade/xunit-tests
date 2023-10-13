using UnitTestMoq.Model;

namespace UnitTestMoq.Services
{
    public interface IProdutoService
    {
        public IEnumerable<Produto> ListarProdutos();
        public Produto SelecionarProdutoPorID(int id);
        public Produto InserirProduto(Produto produto);
        public Produto AtualizarProduto(Produto produto);
        public bool DeletarProduto(int id);
    }
}
