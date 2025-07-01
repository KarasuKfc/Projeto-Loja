using System.Linq;
using System.Collections.Generic;
using trabalhoparte1.Entidades;
using ProjetoLoja.Models;
using ProjetoLoja.Services;
using System.IO;
using trabalhoparte1.Service;

namespace trabalhoparte1.Repositorios
{
    public class ClienteRepositorio
    {
        private List<Cliente> clientes = new List<Cliente>();
        private const string CAMINHO_ARQUIVO = "clientes.json";

        public ClienteRepositorio()
        {
            clientes = ArquivoUtil.CarregarDeArquivo<Cliente>(CAMINHO_ARQUIVO);
        }

        private void Salvar() => ArquivoUtil.SalvarEmArquivo(CAMINHO_ARQUIVO, clientes);


        public void Adicionar(Cliente c)
        {
            clientes.Add(c);
            Salvar();
        }
        public bool Remover(string usuario)
        {
            bool removido = clientes.RemoveAll(c => c.NomeUsuario == usuario) > 0;
            if (removido)
            {
                Salvar();
            }
            return removido;
        }
        
        public Cliente Buscar(string usuario) => clientes.FirstOrDefault(c => c.NomeUsuario == usuario);
        public List<Cliente> ListarTodos() => clientes;
    }
}