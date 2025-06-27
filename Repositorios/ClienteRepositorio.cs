using System.Linq;
using System.Collections.Generic;
using trabalhoparte1.Entidades;
using ProjetoLoja.Models;

namespace trabalhoparte1.Repositorios
{
    public class ClienteRepositorio
    {
        private List<Cliente> clientes = new List<Cliente>();

        public void Adicionar(Cliente c) => clientes.Add(c);
        public bool Remover(string usuario) => clientes.RemoveAll(c => c.NomeUsuario == usuario) > 0;
        public Cliente Buscar(string usuario) => clientes.FirstOrDefault(c => c.NomeUsuario == usuario);
        public List<Cliente> ListarTodos() => clientes;
    }
}