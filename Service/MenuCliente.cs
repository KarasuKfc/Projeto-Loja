using System;
using ProjetoLoja.Models;
using trabalhoparte1.Entidades;

namespace trabalhoparte1.Service
{
    public class MenuCliente
    {
        private Cliente cliente;

        public MenuCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public void Exibir()
        {
            Console.WriteLine($"Olá, {cliente.NomeCompleto}! Seja bem-vindo");
            
        }
    }
}
