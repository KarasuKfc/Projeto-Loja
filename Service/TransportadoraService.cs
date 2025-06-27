using ProjetoLoja.Models;
using trabalhoparte1.Repositorios;
using System;

namespace ProjetoLoja.Services
{

    public class TransportadoraService
    {
        private TransportadoraRepositorio repositorio;

        public TransportadoraService(TransportadoraRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Menu()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n=== Menu Tranportadora ===");
                Console.WriteLine("1- Adicionar Transportadora");
                Console.WriteLine("2- Listar Transportadoras");
                Console.WriteLine("3- Remover Transportadora");
                Console.WriteLine("4- Buscar Transportadora");
                Console.WriteLine("0- Voltar");
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
            Console.WriteLine("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Telefone: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("Valor Frete: ");
            double valorFrete = double.Parse(Console.ReadLine());

            var t = new Transportadora(id, nome, telefone, valorFrete);
            repositorio.Adicionar(t);

            Console.WriteLine("Transportadora cadastrada com sucesso!");
        }

        private void Listar()
        {
            var lista = repositorio.ListarTodos();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma transportadora cadastrada.");
            }
            else
            {
                lista.ForEach(Console.WriteLine);
            }
        }

        private void Remover()
        {
            Console.WriteLine("Informe o ID da tranportadora que será removida: ");
            int id = int.Parse(Console.ReadLine());

            if (repositorio.Remover(id))
            {
                Console.WriteLine("Transportadora removida com sucesso!");
            }
            else
            {
                Console.WriteLine("Transportadora não encontrada.");
            }
        }

        private void Buscar()
        {
            Console.WriteLine("Informe o ID da tranportadora: ");
            int id = int.Parse(Console.ReadLine());

            var t = repositorio.Buscar(id);
            if (t != null)
            {
                Console.WriteLine(t);
            }
            else
            {
                Console.WriteLine("Transportadora não encontrada.");
            }
        }
    }
}
