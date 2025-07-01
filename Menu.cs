using ProjetoLoja.Services;
using System;
using trabalhoparte1.Repositorios;
using trabalhoparte1.Service;

public class Menu
{
    private ProdutoService produtoService;
    private FornecedorService fornecedorService;
    private TransportadoraService transportadoraService;
    private ClienteService clienteService;
    private PedidoService pedidoService;

    public Menu()
    {
        var produtoRepo = new ProdutoRepositorio();
        var fornecedorRepo = new FornecedorRepositorio();
        var transportadoraRepo = new TransportadoraRepositorio();
        var clienteRepo = new ClienteRepositorio();


        produtoService = new ProdutoService(produtoRepo);
        fornecedorService = new FornecedorService(fornecedorRepo);
        transportadoraService = new TransportadoraService(transportadoraRepo);
        clienteService = new ClienteService(clienteRepo);
    }

    public void ExibirMenu()
    {
        int opcao;
        do
        {
            Console.WriteLine("\n=== Menu Principal ===");
            Console.WriteLine("1- Gerenciar Produtos");
            Console.WriteLine("2- Gerenciar Fornecedores");
            Console.WriteLine("3- Gerenciar Transportadoras");
            Console.WriteLine("4- Gerenciar Clientes");
            Console.WriteLine("5- Gerenciar Pedidos");
            Console.WriteLine("0- Sair");
            Console.WriteLine("Opção: ");
            int.TryParse(Console.ReadLine(), out opcao);

            switch (opcao)
            {
                case 1: produtoService.Menu(); break;
                case 2: fornecedorService.Menu(); break;
                case 3: transportadoraService.Menu(); break;
                case 4: clienteService.Menu(); break;
                case 5: pedidoService.Menu(); break;

                case 0: Console.WriteLine("Saindo do sistema..."); break;
            }
        } while (opcao != 0);
    }
}