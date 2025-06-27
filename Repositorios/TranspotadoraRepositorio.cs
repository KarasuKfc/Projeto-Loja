using System.Linq;
using trabalhoparte1.Entidades;
using System.Collections.Generic;
using ProjetoLoja.Models;

namespace trabalhoparte1.Repositorios
{
    public class TransportadoraRepositorio
    {
        private List<Transportadora> transportadoras = new List<Transportadora>();

        public void Adicionar(Transportadora t) => transportadoras.Add(t);
        public bool Remover(int id) => transportadoras.RemoveAll(t => t.Id == id) > 0;
        public Transportadora Buscar(int id) => transportadoras.FirstOrDefault(t => t.Id == id);
        public List<Transportadora> ListarTodos() => transportadoras;
    }
}

