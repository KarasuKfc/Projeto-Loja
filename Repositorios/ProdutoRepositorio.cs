using trabalhoparte1.Entidades;
using System.Collections.Generic;
using System.Linq;
using ProjetoLoja.Models;


namespace trabalhoparte1.Repositorios
{
    public class ProdutoRepositorio
    {
        private List<Produto> produtos = new List<Produto>();

        public void Adicionar(Produto p) => produtos.Add(p);
        public bool Remover(int codigo) => produtos.RemoveAll(p => p.Codigo == codigo) > 0;

        public Produto Buscar(int codigo) => produtos.FirstOrDefault(p => p.Codigo == codigo);
        public List<Produto> ListarTodos() => produtos;
        public Produto BuscarPorNome(string nome) => produtos.FirstOrDefault(p => p.Nome.ToLower().Contains(nome.ToLower()));
    }
}
