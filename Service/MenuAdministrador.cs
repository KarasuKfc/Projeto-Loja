using System;
using trabalhoparte1.Repositorios;
using trabalhoparte1.Entidades;
using ProjetoLoja.Services;

namespace trabalhoparte1.Service
{
    public class MenuAdministrador
    {
        private ProdutoService produtoService;
        private FornecedorService fornecedorService;
        private TransportadoraService transportadoraService;
        private ClienteService clienteService;

        public MenuAdministrador(
            ProdutoRepositorio prodRepo,
            FornecedorRepositorio fornRepo,
            TransportadoraRepositorio transRepo,
            ClienteRepositorio clienteRepo)
        {
            produtoService = new ProdutoService(prodRepo);
            fornecedorService = new FornecedorService(fornRepo);
            transportadoraService = new TransportadoraService(transRepo);
            clienteService = new ClienteService(clienteRepo);
        }

        public void Exibir()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n=== Menu Administrador ===");
                Console.WriteLine("1- Gerenciar Produtos");
                Console.WriteLine("2- Gerenciar Fornecedores");
                Console.WriteLine("3- Gerenciar Transportadoras");
                Console.WriteLine("4- Gerenciar Clientes");
                Console.WriteLine("0- Sair");
                Console.Write("Opção: ");
                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1: produtoService.Menu(); break;
                    case 2: fornecedorService.Menu(); break;
                    case 3: transportadoraService.Menu(); break;
                    case 4: clienteService.Menu(); break;
                }
            } while (opcao != 0);
        }
    }
}