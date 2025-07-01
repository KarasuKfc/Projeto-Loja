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
        private Dictionary<string, Cliente> clientePorUsuario;

        public ClienteRepositorio()
        {
            clientes = ArquivoUtil.CarregarDeArquivo<Cliente>(CAMINHO_ARQUIVO);
            clientePorUsuario = clientes.ToDictionary(c => c.NomeUsuario);
        }

        private void Salvar() => ArquivoUtil.SalvarEmArquivo(CAMINHO_ARQUIVO, clientes);


        public void Adicionar(Cliente c)
        {
            clientes.Add(c);
            clientePorUsuario[c.NomeUsuario] = c;
            Salvar();
        }
        public bool Remover(string usuario)
        {
            bool removido = clientes.RemoveAll(c => c.NomeUsuario == usuario) > 0;
            if (removido)
            {
                clientePorUsuario.Remove(usuario);
                Salvar();
            }
            return removido;
        }

        public Cliente Buscar(string usuario)
        {
            clientePorUsuario.TryGetValue(usuario, out Cliente c);
            return c;
        }
        
        public List<Cliente> ListarTodos() => clientes;
    }
}