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
        private List<Produto> produtos = new List<Produto>();
        private const string CAMINHO_ARQUIVO = "produtos.json";

        public ProdutoRepositorio()
        {
            produtos = ArquivoUtil.CarregarDeArquivo<Produto>(CAMINHO_ARQUIVO);
        }

        public void Adicionar(Produto p)
        {
            produtos.Add(p);
            Salvar();
        }
        public bool Remover(int codigo)
        {
            bool removido = produtos.RemoveAll(p => p.Codigo == codigo) > 0;
            if (removido)
            {
                Salvar();
            }
            return removido;
        }

        public Produto Buscar(int codigo) => produtos.FirstOrDefault(p => p.Codigo == codigo);
        public List<Produto> ListarTodos() => produtos;
        public Produto BuscarPorNome(string nome) => produtos.FirstOrDefault(p => p.Nome.ToLower().Contains(nome.ToLower()));

        private void Salvar() => ArquivoUtil.SalvarEmArquivo(CAMINHO_ARQUIVO, produtos);
    }
}
