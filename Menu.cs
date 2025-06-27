using ProjetoLoja.Services;
using System;
using trabalhoparte1.Repositorios;

public class Menu
{
    private ProdutoService produtoService;
    private FornecedorService fornecedorService;

    public Menu()
    {
        var produtoRepo = new ProdutoRepositorio();
        var fornecedorRepo = new FornecedorRepositorio();


        produtoService = new ProdutoService(produtoRepo);
        fornecedorService = new FornecedorService(fornecedorRepo);
    }

    public void ExibirMenu()
    {
        int opcao;
        do
        {
            Console.WriteLine("\n=== Menu Principal ===");
            Console.WriteLine("1- Gerenciar Produtos");
            Console.WriteLine("2- Gerenciar Fornecedores");
            Console.WriteLine("0- Sair");
            Console.WriteLine("Opção: ");
            int.TryParse(Console.ReadLine(), out opcao);

            switch (opcao)
            {
                case 1: produtoService.Menu(); break;
                case 2: fornecedorService.Menu(); break;

                case 0: Console.WriteLine("Saindo do sistema..."); break;
            }
        } while (opcao != 0);
    }
}