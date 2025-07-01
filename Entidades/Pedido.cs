using System;
using System.Collections.Generic;
using ProjetoLoja.Models;

namespace trabalhoparte1.Entidades
{
    public class Pedido
    {
        private static int proximoNumero = 1;

        public int Numero { get; private set; }
        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public List<ItemPedido> Itens { get; set; }
        public Transportadora Transportadora { get; set; }

        public double TotalItens => CalcularTotalItens();
        public double Frete => Transportadora?.ValorFrete ?? 0;
        public double TotalGeral => TotalItens + Frete;

        public Pedido(Cliente cliente, List<ItemPedido> items, Transportadora transportadora)
        {
            Numero = proximoNumero++;
            Cliente = cliente;
            Data = DateTime.Now;
            Itens = items;
            Transportadora = transportadora;
        }

        private double CalcularTotalItens()
        {
            double total = 0;
            foreach (var item in Itens)
            {
                total += item.Total;
            }
            return total;
        }

        public override string ToString()
        {
            return $"Pedido {Numero} - {Data:dd/MM/yyyy HH:mm}\n" +
                   $"Cliente: {Cliente.NomeCompleto}\n" +
                   $"Itens:\n" +
                   $"{string.Join("\n", Itens)}\n" +
                   $"Frete: R${Frete:F2}\n" +
                   $"Total: R${TotalGeral:F2}\n";

        }
        
    }

}

