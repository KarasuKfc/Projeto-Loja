using System;
using System.Collections.Generic;
using System.Linq;
using trabalhoparte1.Entidades;
using trabalhoparte1.Entidades.Enums;

namespace trabalhoparte1.Service
{
    public class PedidoService
    {
        private List<Pedido> pedidos;

        public PedidoService(List<Pedido> pedidos)
        {
            this.pedidos = pedidos;
        }

        public void Menu()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n=== Gerenciar Pedidos ===");
                Console.WriteLine("1- Listar Todos os Pedidos");
                Console.WriteLine("2- Consultar Pedido por Número");
                Console.WriteLine("3- Alterar Status do Pedido");
                Console.WriteLine("0- Voltar");
                Console.WriteLine("Opcao: ");
                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1: ListarTodos(); break;
                    case 2: ConsultarPorNumero(); break;
                    case 3: AlterarStatus(); break;
                }

            } while (opcao != 0);
        }

        private void ListarTodos()
        {
            if (pedidos.Count == 0)
            {
                Console.WriteLine("Nenhum pedido encontrado");
                return;
            }

            foreach (var pedido in pedidos)
            {
                Console.WriteLine("\n--- PEDIDO --- ");
                Console.WriteLine(pedido);
            }
        }

        private void ConsultarPorNumero()
        {
            Console.Write("Número do Pedido: ");
            int numero = int.Parse(Console.ReadLine());

            var pedido = pedidos.FirstOrDefault(p => p.Numero == numero);
            if (pedido != null)
            {
                Console.WriteLine(pedido);
            }
            else
            {
                Console.WriteLine("Pedido não encontrado");
            }
        }

        private void AlterarStatus()
        {
            Console.Write("Número do Pedido: ");
            int numero = int.Parse(Console.ReadLine());

            var pedido = pedidos.FirstOrDefault(p => p.Numero == numero);
            if (pedido == null)
            {
                Console.WriteLine("Pedido não encontrado");
                return;
            }

            Console.WriteLine("Status atual: " + pedido.Status);
            Console.WriteLine("1- Marcar como Enviado");
            Console.WriteLine("2- Cancelar Pedido");
            Console.Write("Opcao: ");
            int.TryParse(Console.ReadLine(), out int escolha);

            if (escolha == 1 && pedido.Status == StatusPedido.Pendente)
            {
                pedido.MarcarComoEnviado();
                Console.WriteLine("Pedido marcado como Enviado.");
            }
            else if (escolha == 2 && pedido.Status == StatusPedido.Pendente)
            {
                pedido.Cancelar();
                Console.WriteLine("Pedido cancelado.");
            }
            else
            {
                Console.WriteLine("Ação invalida ou pedido finalizado.");
            }
        }
    }
}
