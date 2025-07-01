using System;
using ProjetoLoja.Models;
using trabalhoparte1.Entidades;
using trabalhoparte1.Repositorios;

namespace trabalhoparte1.Service
{
    public class MenuCliente
    {
        private Cliente cliente;
        private CarrinhoService carrinhoService;

        public MenuCliente(Cliente cliente)
        {
            this.cliente = cliente;

            var produtoRepo = new ProdutoRepositorio();
            var transportadoraRepo = new TransportadoraRepositorio();

            carrinhoService = new CarrinhoService(produtoRepo, transportadoraRepo);
        }

        public void Exibir()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n=== Menu Cliente ===");
                Console.WriteLine($"Olá, {cliente.NomeCompleto}! Seja bem-vindo");
                Console.WriteLine("1- Fazer pedido");
                Console.WriteLine("2- Meus pedidos");
                Console.WriteLine("0- Sair");
                Console.Write("Opção: ");
                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1: carrinhoService.Comprar(cliente); break;
                    case 2: carrinhoService.ConsultarPedidos(cliente); break;
                }
            } while (opcao != 0);
        }
    }
}
