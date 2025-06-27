using ProjetoLoja.Models;
using trabalhoparte1.Repositorios;
using System;
using System.Reflection;

namespace ProjetoLoja.Services
{
    public class ClienteService
    {
        private ClienteRepositorio repositorio;

        public ClienteService(ClienteRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Menu()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n=== Menu Clientes ===");
                Console.WriteLine("1- Adicionar Cliente");
                Console.WriteLine("2- Listar Clientes");
                Console.WriteLine("3- Remover Cliente");
                Console.WriteLine("4- Buscar Cliente por Usuário");
                Console.WriteLine("0- Voltar");
                Console.Write("Opção: ");
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
            Console.WriteLine("Usuário: ");
            string usuario = Console.ReadLine();

            Console.WriteLine("Senha: ");
            string senha = Console.ReadLine();

            Console.WriteLine("Nome Completo: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Endereço: ");
            string endereco = Console.ReadLine();

            var cliente = new Cliente(usuario, senha, nome, endereco);
            repositorio.Adicionar(cliente);

            Console.WriteLine("Cliente adicionado com sucesso!");
        }

        private void Listar()
        {
            var lista = repositorio.ListarTodos();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
            }
            else
            {
                lista.ForEach(Console.WriteLine);
            }
        }

        private void Remover()
        {
            Console.WriteLine("Informe o usuário do cliente: ");
            string usuario = Console.ReadLine();

            if (repositorio.Remover(usuario))
            {
                Console.WriteLine("Cliente removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        private void Buscar()
        {
            Console.Write("Informe o usuário do cliente: ");
            string usuario = Console.ReadLine();

            var c = repositorio.Buscar(usuario);
            if (c != null)
            {
                Console.WriteLine(c);
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }
    }
}