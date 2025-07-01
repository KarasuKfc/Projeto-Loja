using trabalhoparte1.Entidades;
using System.Collections.Generic;
using System.Linq;
using ProjetoLoja.Models;
using ProjetoLoja.Services;
using System.IO;
using trabalhoparte1.Service;


namespace trabalhoparte1.Repositorios
{

    public class ProdutoRepositorio
    {
        private Dictionary<int, Produto> produtoPorCodigo;
        private List<Produto> produtos = new List<Produto>();
        private const string CAMINHO_ARQUIVO = "produtos.json";

        public ProdutoRepositorio()
        {
            produtos = ArquivoUtil.CarregarDeArquivo<Produto>(CAMINHO_ARQUIVO);
            produtoPorCodigo = produtos.ToDictionary(p => p.Codigo);
        }

        public void Adicionar(Produto p)
        {
            produtos.Add(p);
            produtoPorCodigo[p.Codigo] = p;
            Salvar();
        }
        public bool Remover(int codigo)
        {
            var removido = produtos.RemoveAll(p => p.Codigo == codigo) > 0;
            if (removido)
            {
                produtoPorCodigo.Remove(codigo);
                Salvar();
            }
            return removido;
        }

        public Produto Buscar(int codigo)
        {
            produtoPorCodigo.TryGetValue(codigo, out Produto produto);
            return produto;
        }
        public List<Produto> ListarTodos() => produtos;
        public Produto BuscarPorNome(string nome) => produtos.FirstOrDefault(p => p.Nome.ToLower().Contains(nome.ToLower()));

        private void Salvar() => ArquivoUtil.SalvarEmArquivo(CAMINHO_ARQUIVO, produtos);
    }
}
