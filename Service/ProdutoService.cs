using ProjetoLoja.Models;
using System;
using trabalhoparte1.Repositorios;

namespace ProjetoLoja.Services
{
    public class ProdutoService
    {
        private ProdutoRepositorio repositorio;

        public ProdutoService(ProdutoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Menu()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n==== Menu de Produtos ====");
                Console.WriteLine("1- Adicionar Produto");
                Console.WriteLine("2- Listar Produtos");
                Console.WriteLine("3- Remover Produto");
                Console.WriteLine("4- Buscar Produto por Código");
                Console.WriteLine("0- Voltar");
                Console.WriteLine("Opcão: ");
                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1: Adicionar(); break;
                    case 2: Listar(); break;
                    case 3: Remover(); break;
                    case 4: Buscar(); break;
                }
            } while (opcao != 0);
        }

        private void Adicionar()
        {
            Console.WriteLine("=== Adicionar Produto ===");
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Estoque: ");
            int estoque = int.Parse(Console.ReadLine());

            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine());

            Produto p = new Produto(codigo, nome, descricao, estoque, preco);
            repositorio.Adicionar(p);

            Console.WriteLine("Produto adicionado com sucesso!");
        }

        private void Listar()
        {
            Console.WriteLine("=== Listar Produtos ===");
            var lista = repositorio.ListarTodos();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
            }
            else
            {
                lista.ForEach(Console.WriteLine);
            }
        }

        private void Remover()
        {
            Console.WriteLine("=== Remover Produto ===");
            Console.WriteLine("Informe o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            if (repositorio.Remover(codigo))
            {
                Console.WriteLine("Produto removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
        
        private void Buscar()
        {
            Console.WriteLine("=== Buscar Produto por Código ===");
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());

            Produto produto = repositorio.Buscar(codigo);
            if (produto != null)
            {
                Console.WriteLine(produto);
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
    }
}