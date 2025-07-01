using System;
using System.Collections.Generic;
using ProjetoLoja.Models;
using trabalhoparte1.Entidades.Enums;

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

        public StatusPedido Status { get; set; }
        public DateTime? DataEnvio { get; private set; }
        public DateTime? DataCancelamento { get; private set; }

        public Pedido(Cliente cliente, List<ItemPedido> items, Transportadora transportadora)
        {
            Numero = proximoNumero++;
            Cliente = cliente;
            Data = DateTime.Now;
            Itens = items;
            Transportadora = transportadora;
            Status = StatusPedido.Pendente;
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

        public void MarcarComoEnviado()
        {
            Status = StatusPedido.Enviado;
            DataEnvio = DateTime.Now;
        }

        public void Cancelar()
        {
            Status = StatusPedido.Cancelado;
            DataCancelamento = DateTime.Now;
        }

        public override string ToString()
        {
            string detalhes = $"Pedido {Numero} - {Data:dd/MM/yyyy HH:mm}\n" +
                                $"Cliente: {Cliente.NomeCompleto}\n" +
                                $"Status: {Status}";

            if (Status == StatusPedido.Enviado && DataEnvio.HasValue)
            {
                detalhes += $"\nData de Envio: {DataEnvio.Value:dd/MM/yyyy HH:mm}";
            }

            if (Status == StatusPedido.Cancelado && DataCancelamento.HasValue)
            {
                detalhes += $"\nData de Cancelamento: {DataCancelamento.Value:dd/MM/yyyy HH:mm}";
            }

            detalhes += $"\nItens:\n";
            detalhes += string.Join("\n", Itens);
            detalhes += $"\nFrete: R${Frete:F2}\nTotal: R${TotalGeral:F2}";

            return detalhes;
        }
        
    }

}

