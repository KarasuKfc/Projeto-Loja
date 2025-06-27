using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoLoja.Models;

namespace trabalhoparte1.Repositorios
{
    public class FornecedorRepositorio
    {
        public List<Fornecedor> fornecedores = new List<Fornecedor>();

        public void Adicionar(Fornecedor f) => fornecedores.Add(f);
        public bool Remover(int cnpj) => fornecedores.RemoveAll(f => f.Cnpj == cnpj) > 0;
        public Fornecedor Buscar(int cnpj) => fornecedores.FirstOrDefault(f => f.Cnpj == cnpj);
        public List<Fornecedor> ListarTodos() => fornecedores;
        public Fornecedor BuscarPorNome(string nome) =>
            fornecedores.FirstOrDefault(f => f.Nome.ToLower().Contains(nome.ToLower())); 
    }
}