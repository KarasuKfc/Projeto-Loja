using System.Linq;
using trabalhoparte1.Entidades;
using System.Collections.Generic;
using ProjetoLoja.Models;
using ProjetoLoja.Services;
using System.IO;
using trabalhoparte1.Service;

namespace trabalhoparte1.Repositorios
{
    public class TransportadoraRepositorio
    {
        private List<Transportadora> transportadoras = new List<Transportadora>();
        private const string CAMINHO_ARQUIVO = "transportadoras.json";

        public TransportadoraRepositorio()
        {
            transportadoras = ArquivoUtil.CarregarDeArquivo<Transportadora>(CAMINHO_ARQUIVO);
        }

        private void Salvar() => ArquivoUtil.SalvarEmArquivo(CAMINHO_ARQUIVO, transportadoras);

        public void Adicionar(Transportadora t)
        {
            transportadoras.Add(t);
            Salvar();
        }
        public bool Remover(int id)
        {
            bool removido = transportadoras.RemoveAll(t => t.Id == id) > 0;
            if (removido)
            {
                Salvar();
            }
            return removido;

        }
        public Transportadora Buscar(int id) => transportadoras.FirstOrDefault(t => t.Id == id);
        public List<Transportadora> ListarTodos() => transportadoras;
    }
}

