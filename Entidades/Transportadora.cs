using trabalhoparte1.Entidades;

namespace ProjetoLoja.Models
{
    public class Transportadora : IEntidadeComCodigo
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double PrecoPorKm { get; set; }

        public Transportadora(int codigo, string nome, double precoPorKm)
        {
            Codigo = codigo;
            Nome = nome;
            PrecoPorKm = precoPorKm;
        }
    }
}