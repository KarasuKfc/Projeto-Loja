using System;
using System.Collections.Generic;
using trabalhoparte1.Entidades;
using trabalhoparte1.Repositorios;
using System.Linq;
using ProjetoLoja.Models;
using trabalhoparte1.Entidades.Execeptions;

namespace trabalhoparte1.Service
{
    public class CarrinhoService
    {
        private ProdutoRepositorio produtoRepo;
        private TransportadoraRepositorio transportadoraRepo;
        private List<Pedido> pedidos = new List<Pedido>();
        private const string CAMINHO_ARQUIVO = "pedidos.json";

        public CarrinhoService(ProdutoRepositorio produtoRepo, TransportadoraRepositorio transportadoraRepo)
        {
            this.produtoRepo = produtoRepo;
            this.transportadoraRepo = transportadoraRepo;
            pedidos = ArquivoUtil.CarregarDeArquivo<Pedido>(CAMINHO_ARQUIVO);
        }



        public void Comprar(Cliente cliente)
        {
            try
            {
                var itens = new List<ItemPedido>();
                while (true)
                {
                    Console.WriteLine("\nProdutos disponíveis:");
                    var produtos = produtoRepo.ListarTodos().Where(p => p.Estoque > 0).ToList();

                    for (int i = 0; i < produtos.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {produtos[i]}");
                    }

                    Console.Write("Número de produtos (0 para finalizar): ");
                    if (!int.TryParse(Console.ReadLine(), out int escolha) || escolha == 0) break;

                    if (escolha < 1 || escolha > produtos.Count)
                    {
                        throw new ProdutoNaoEncontradoException("Produto não encontrado.");
                    }

                    var produto = produtos[escolha - 1];

                    Console.Write($"Estoque: {produto.Estoque} - Quantidade desejada: ");
                    int qtd = int.Parse(Console.ReadLine());

                    if (qtd > produto.Estoque)
                    {
                        throw new EstoqueInsuficienteExeception("Quantidade solicitada maior que a disponível");
                    }

                    produto.Estoque -= qtd;
                    itens.Add(new ItemPedido(produto, qtd));

                    Console.WriteLine($"{produto.Nome} adicionado ao carrinho!");
                }

                if (itens.Count == 0)
                {
                    Console.WriteLine("Carrinho vazio. Cancelando a compra...");
                    return;
                }

                Console.WriteLine("\nTransportadoras disponíveis: ");
                var listaT = transportadoraRepo.ListarTodos();
                for (int i = 0; i < listaT.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {listaT[i]}");
                }

                Console.Write("Escolha uma transportadora: ");
                int escolhaT = int.Parse(Console.ReadLine());
                var transportadora = listaT[escolhaT - 1];

                var pedido = new Pedido(cliente, itens, transportadora);
                pedidos.Add(pedido);

                Console.WriteLine("\nPedido realizado com sucesso!");
                Console.WriteLine(pedido);
                ArquivoUtil.SalvarEmArquivo(CAMINHO_ARQUIVO, pedidos);

            }
            catch (EstoqueInsuficienteException ex)
            {
                Console.WriteLine($"[!] Erro: {ex.Message}");
            }
            catch (ProdutoNaoEncontradoException ex)
            {
                Console.WriteLine($"[!] Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[!] Erro inesperado: {ex.Message}");
            }
        }


        public void ConsultarPedidos(Cliente cliente)
        {
            var meusPedidos = pedidos.Where(p => p.Cliente.NomeUsuario == cliente.NomeUsuario).ToList();

            if (meusPedidos.Count == 0)
            {
                Console.WriteLine("Você ainda não possui pedidos.");
                return;
            }

            foreach (var pedido in meusPedidos)
            {
                Console.WriteLine("\n---PEDIDO---");
                Console.WriteLine(pedido);
            }
        }

        public void ConsultarPorNumero(int numero, Cliente cliente)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Numero == numero && p.Cliente.NomeUsuario == cliente.NomeUsuario);
            if (pedido != null)
            {
                Console.WriteLine("\n--- Detalhes do Pedido ---");
                Console.WriteLine(pedido);
            }
            else
            {
                Console.WriteLine("Pedido não encontrado.");
            }
        }

        public void ConsultarPorIntervalo(DateTime inicio, DateTime fim, Cliente cliente)
        {
            var encontrados = pedidos
                .Where(p => p.Cliente.NomeUsuario == cliente.NomeUsuario && p.Data <= fim).ToList();

            if (encontrados.Count == 0)
            {
                Console.WriteLine("Nenhum pedido encontrado no intervalo infomado.");
                return;
            }

            foreach (var pedido in encontrados)
            {
                Console.WriteLine("\n---PEDIDO---");
                Console.WriteLine(pedido);
            }
                
        }
    }
}