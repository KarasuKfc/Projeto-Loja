using ProjetoLoja.Models;
using trabalhoparte1.Repositorios;
using System;

namespace ProjetoLoja.Services
{
    public class FornecedorService
    {
        private FornecedorRepositorio repositorio;

        public FornecedorService(FornecedorRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Menu()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n=== Menu Fornecedor ===");
                Console.WriteLine("1- Adicionar Fornecedor");
                Console.WriteLine("2- Listar Fornecedores");
                Console.WriteLine("3- Remover Fornecedor");
                Console.WriteLine("4- Buscar Fornecedor por CNPJ");
                Console.WriteLine("0- Sair");
                Console.WriteLine("Opção: ");
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
            Console.Write("CNPJ (somente números): ");
            int cnpj = int.Parse(Console.ReadLine());

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();

            var f = new Fornecedor(cnpj, nome, endereco);
            repositorio.Adicionar(f);

            Console.WriteLine("Fornecedor adicionado com sucesso!");
        }

        private void Listar()
        {
            Console.WriteLine("=== Lista de Fornecedores ===");
            var lista = repositorio.ListarTodos();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum fornecedor cadastrado.");
            }
            else
            {
                lista.ForEach(Console.WriteLine);
            }
        }

        private void Remover()
        {
            Console.WriteLine("Informe o CNPJ do fornecedor a ser removido:");
            int cnpj = int.Parse(Console.ReadLine());

            if (repositorio.Remover(cnpj))
            {
                Console.WriteLine("Fornecedor removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Fornecedor não encontrado.");
            }
        }

        private void Buscar()
        {
            Console.WriteLine("Informe o CNPJ do fornecedor: ");
            int cnpj = int.Parse(Console.ReadLine());

            var fornecedor = repositorio.Buscar(cnpj);
            if (fornecedor != null)
            {
                Console.WriteLine(fornecedor);
            }
            else
            {
                Console.WriteLine("Fornecedor não encontrado.");
            }
        }
    }
}
            