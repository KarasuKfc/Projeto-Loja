using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoLoja.Models;
using ProjetoLoja.Services;
using System.IO;
using trabalhoparte1.Service;

namespace trabalhoparte1.Repositorios
{
    public class FornecedorRepositorio
    {
        public List<Fornecedor> fornecedores = new List<Fornecedor>();
        private const string CAMINHO_ARQUIVO = "fornecedores.json";
        private Dictionary<int, Fornecedor> fornecedorPorCnpj;

        public FornecedorRepositorio()
        {
            fornecedores = ArquivoUtil.CarregarDeArquivo<Fornecedor>(CAMINHO_ARQUIVO);
            fornecedorPorCnpj = fornecedores.ToDictionary(f => f.Cnpj);
        }

        public void Salvar() => ArquivoUtil.SalvarEmArquivo(CAMINHO_ARQUIVO, fornecedores);

        public void Adicionar(Fornecedor f)
        {
            fornecedores.Add(f);
            fornecedorPorCnpj[f.Cnpj] = f;
            Salvar(); 
        }
        public bool Remover(int cnpj)
        {
            bool removido = fornecedores.RemoveAll(f => f.Cnpj == cnpj) > 0;
            if (removido)
            {
                fornecedorPorCnpj.Remove(cnpj);
                Salvar();
            }
            return removido;
        }

        public Fornecedor Buscar(int cnpj)
        {
            fornecedorPorCnpj.TryGetValue(cnpj, out Fornecedor f);
            return f;
        }
        public List<Fornecedor> ListarTodos() => fornecedores;
        public Fornecedor BuscarPorNome(string nome) =>
            fornecedores.FirstOrDefault(f => f.Nome.ToLower().Contains(nome.ToLower())); 
    }
}